# GLAS Server — Backend Overview

## 1. Общая архитектура

**Технологический стек**

- ASP.NET Core **.NET 9.0**
- **Entity Framework Core 9** + **Npgsql** (PostgreSQL)
- JWT-аутентификация (System.IdentityModel.Tokens.Jwt)
- Хеширование паролей — **BCrypt.Net-Next**
- Swagger (Swashbuckle) для документации API

**Роль сервиса сейчас**

На текущем этапе backend реализует:

- регистрацию и аутентификацию пользователя по номеру телефона;
- выдачу JWT-токена;
- смену пароля;
- восстановление пароля через SMS-код (Mock/Twilio);
- заготовки под модели обращений, категорий, статусов и уведомлений.

Функции работы с обращениями (issues), отчётами, аналитикой и AI пока не реализованы.

---

## 2. Конфигурация и запуск

**Точка входа:** `Program.cs`

- HTTP-сервер слушает `http://0.0.0.0:5024`.
- Используется Kestrel (`ConfigureKestrel`) с `ListenAnyIP(5024)`.
- В `ConfigureServices` регистрируется:
  - `AppDbContext` (EF Core, PostgreSQL);
  - `IUserService` → `UserService`;
  - `IJwtTokenProvider` → `JwtTokenProvider`;
  - `ISmsProvider` → `SmsProvider`;
  - `AddControllers()`, `AddEndpointsApiExplorer()`, `AddSwaggerGen()`.
- В dev-режиме включён Swagger UI по маршруту `/swagger`.
- Подключены middleware:
  - `UseAuthentication()`;
  - `UseAuthorization()`;
  - `MapControllers()`.

**Конфигурация (`appsettings.json`)**

- `Jwt`:
  - `SecretKey` — симметричный ключ (должен быть длинным для HMAC);
  - `Issuer` — издатель токена (по умолчанию `"GLASServer"`);
  - `Audience` — целевая аудитория (по умолчанию `"GLASClient"`);
  - `ExpiresInMinutes` — время жизни токена.
- `SmsSettings`:
  - `Provider` — `"Mock"` или `"Twilio"`;
  - блок `Twilio` с `AccountSid`, `AuthToken`, `FromNumber`.
- Строка подключения к БД читается из `ConnectionStrings:DefaultConnection`. Если её нет, используется fallback:

```text
Host=localhost;Port=5432;Database=glas_db;Username=postgres;Password=12345
```

**Скрипты запуска**

- `entrypoint.sh` (используется в Docker/CI):
  - ждёт доступности PostgreSQL (`pg_isready`);
  - запускает миграции: `dotnet ef database update --project GLAS_Server`;
  - запускает сервер: `dotnet watch run --urls "http://0.0.0.0:5024"`.
- `run_all_tests.bat` (Windows):
  - запускает сервер (`dotnet run`);
  - через `curl` выполняет сценарий:
    1. регистрация пользователя;
    2. запрос кода восстановления пароля;
    3. попытка смены пароля с кодом `123456`;
    4. логин с новым паролем.

> Важно: папка `GLAS_Server/Migrations` находится в `.gitignore` и не хранится в репозитории. Миграции нужно создавать локально (через `dotnet ef migrations add`).

---

## 3. Модель данных

**Контекст БД:** `Data/AppDbContext.cs`

```csharp
public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Notification> Notifications => Set<Notification>();
    public DbSet<NotificationSettings> NotificationsSettings => Set<NotificationSettings>();
}
```

**Поддерживаемые сущности**

- `User`
  - `Id` — первичный ключ;
  - `AccountID` — дополнительный идентификатор (сейчас не используется в логике);
  - `PhoneNumber`, `FirstName`, `LastName`, `Password` (BCrypt-хэш), `BirthDate`;
  - `PasswordResetOpt: PasswordResetOptions?` — опции восстановления пароля через SMS (см. раздел «Ограничения»).
- `PasswordResetOptions`
  - `PasswordResetCode` — код восстановления;
  - `PasswordResetCodeExpiry` — срок действия кода.
- `Notification`
  - заготовка под личные уведомления (заголовок, текст, время, флаг активности, тип).
- `NotificationSettings`
  - настройки уведомлений пользователя (вкл/выкл достижения, общие, звук, вибрация, время напоминаний).

**Заготовки (ещё не подключены к DbContext)**

- `Issuses` (опечатка, по смыслу — Issue):
  - `UserID`, `Title`, `Description`, `CategoryID`, `StatusID`, `AssignedDepartment`;
  - геоданные: `Latitude`, `Longitude`, `Address`;
  - анонимность: `IsAnonymous`, `AnonymousToken`;
  - `CreatedAt`, `UpdatedAt`.
- `Categories`
  - `Name`, `Description`, `Department`, `Priority`.
- `Statuses`
  - `Name`, `Descripton` (есть опечатка в имени свойства).

На данный момент сущности `Issuses`, `Categories`, `Statuses` не добавлены в `AppDbContext`, поэтому таблицы для них EF не создаёт и код нигде их не использует. Это задел под реализацию справочников и обращений в соответствии с ТЗ.

---

## 4. Аутентификация и работа с пользователем

### 4.1. JWT-токены

**Интерфейс:** `Services/Interfaces/IJwtTokenProvider.cs`

```csharp
string GenerateToken(uint userId, string phoneNumber);
```

**Реализация:** `Services/JwtTokenProvider.cs`

- Берёт настройки из `IConfiguration` (`Jwt:SecretKey`, `Jwt:Issuer`, `Jwt:Audience`, `Jwt:ExpiresInMinutes`).
- Создаёт JWT с алгоритмом `HmacSha256`.
- Включает клеймы:
  - `ClaimTypes.NameIdentifier` — идентификатор пользователя;
  - `ClaimTypes.MobilePhone` — номер телефона.

В `Program.cs` настраивается `JwtBearer`:

- проверка подписи, `Issuer`, `Audience`, срока жизни (`ValidateLifetime = true`, `ClockSkew = TimeSpan.Zero`).

### 4.2. SMS-провайдер

**Интерфейс:** `Services/Interfaces/ISmsProvider.cs`

```csharp
Task<bool> SendSmsAsync(string phoneNumber, string message);
```

**Реализация:** `Services/SmsProvider.cs`

- Опирается на `SmsSettings:Provider`:
  - `"Mock"` — логирует SMS в консоль и логгер;
  - `"Twilio"` — каркас интеграции с Twilio (фактический вызов SDK закомментирован, но предусмотрен).
- При ошибках Twilio падает обратно в `Mock`.

### 4.3. Сервис пользователя

**Интерфейс:** `Services/Interfaces/IUserService.cs`

Основные методы:

- `RegisterAsync(RegisterRequest request)`
- `LoginAsync(LoginRequest request)`
- `GetProfileAsync(uint id)`
- `UpdateProfileAsync(UserProfile request)`
- `ChangePasswordAsync(ChangePasswordRequest request)`
- `RequestPasswordResetAsync(string phoneNumber)`
- `VerifyAndResetPasswordAsync(VerifyPasswordResetCodeRequest request)`

**Реализация:** `Services/UserService.cs`

- **Регистрация (`RegisterAsync`)**
  - Проверяет, что все поля заполнены.
  - Проверяет уникальность `PhoneNumber`.
  - Хеширует пароль через BCrypt.
  - Сохраняет `User` в БД.

- **Логин (`LoginAsync`)**
  - Ищет пользователя по `PhoneNumber`.
  - Проверяет пароль через BCrypt.
  - Генерирует JWT-токен.
  - Возвращает `LoginResponse` (базовые данные профиля + токен).

- **Профиль (`GetProfileAsync`)**
  - По `Id` достаёт пользователя.
  - Возвращает `UserProfile` (сейчас заполняет только `FirstName`, `LastName`, `BirthDate`).

- **Обновление профиля (`UpdateProfileAsync`)**
  - Ищет пользователя по `PhoneNumber`.
  - Обновляет `BirthDate` (остальные поля пока не трогаются).

- **Смена пароля (`ChangePasswordAsync`)**
  - Проверка наличия телефона и паролей.
  - Проверка старого пароля.
  - Валидация нового пароля: длина ≥ 8, хотя бы одна буква и одна цифра.
  - Сохранение нового BCrypt-хэша.

- **Запрос кода восстановления (`RequestPasswordResetAsync`)**
  - Ищет пользователя по телефону.
  - Генерирует 6-значный код.
  - Пытается сохранить код и срок действия (10 минут) в `user.PasswordResetOpt`.
  - Отправляет SMS через `ISmsProvider`.
  - При неудаче отправки сбрасывает код и expiry.

- **Подтверждение кода и смена пароля (`VerifyAndResetPasswordAsync`)**
  - Проверяет наличие всех полей.
  - Ищет пользователя по телефону.
  - Проверяет наличие и срок действия кода из `PasswordResetOpt`.
  - Сравнивает код, валидирует новый пароль.
  - Сохраняет новый BCrypt-хэш пароля и сбрасывает код.

---

## 5. HTTP API

**Единственный контроллер:** `Controllers/UserController.cs`

Базовый маршрут: `/api/user`.

### 5.1. Получение профиля

- `GET /api/user/profile/{id}`
- Требуется JWT (`[Authorize]`).
- Параметр `id` — `uint`, идентификатор пользователя.
- Возвращает:
  - `200 OK` + `UserProfile` при успехе;
  - `404 NotFound` при отсутствии пользователя.

### 5.2. Регистрация

- `POST /api/user/register`
- Доступен без токена (`[AllowAnonymous]`).
- Тело (`RegisterRequest`):

```json
{
  "phoneNumber": "+79990000000",
  "firstName": "Иван",
  "lastName": "Иванов",
  "password": "Password123",
  "birthDate": "1990-01-01"
}
```

- Ответ:
  - `200 OK` + текст `"User registered!"`;
  - `400 BadRequest` + сообщение об ошибке (например, `"User already exists"`).

### 5.3. Логин

- `POST /api/user/login`
- Доступен без токена (`[AllowAnonymous]`).
- Тело (`LoginRequest` — фактически используются поля `phoneNumber` и `password`):

```json
{
  "phoneNumber": "+79990000000",
  "password": "Password123"
}
```

- Ответ:
  - `200 OK` + `LoginResponse`:

```json
{
  "accountID": 1,
  "firstName": "Иван",
  "lastName": "Иванов",
  "phoneNumber": "+79990000000",
  "birthDate": "1990-01-01",
  "token": "jwt-token-here"
}
```

  - `401 Unauthorized` + `"Invalid credentials"` при ошибке логина.

### 5.4. Запрос кода восстановления пароля

- `POST /api/user/request-password-reset`
- Доступен без токена.
- Тело (`ResetPasswordViaSmsRequest`):

```json
{
  "phoneNumber": "+79990000000"
}
```

- Ответ:
  - `200 OK` + `"Reset code sent to your phone"` при успехе;
  - `400 BadRequest` + текст ошибки (например, `"User not found"`).

### 5.5. Подтверждение кода и смена пароля

- `POST /api/user/verify-password-reset`
- Доступен без токена.
- Тело (`VerifyPasswordResetCodeRequest`):

```json
{
  "phoneNumber": "+79990000000",
  "code": "123456",
  "newPassword": "NewPassword123"
}
```

- Ответ:
  - `200 OK` + `"Password reset successfully"` при успехе;
  - `400 BadRequest` + текст ошибки (`"No password reset request found"`, `"Reset code has expired"`, `"Invalid reset code"` и т.п.).

---

## 6. Ограничения и TODO

1. **PasswordResetOptions / PasswordResetOpt**
   - В `User` поле `PasswordResetOpt`:
     - объявлено как `PasswordResetOptions?`, но не инициализируется;
     - используется без проверки на `null`.
   - Это может приводить к `NullReferenceException` при первом запросе восстановления пароля.
   - Также `PasswordResetOptions` не сконфигурирован как owned-тип EF, поэтому его поля могут не сохраняться в БД.
   - Рекомендуется:
     - инициализировать `PasswordResetOpt` в конструкторе `User`;
     - либо явно настроить `OwnsOne` в `OnModelCreating`.

2. **Модели обращений и справочников**
   - `Issuses`, `Categories`, `Statuses` не подключены к `AppDbContext` и не используются.
   - Следующие шаги:
     - добавить `DbSet<Issuses>`, `DbSet<Categories>`, `DbSet<Statuses>` в контекст;
     - сгенерировать миграции;
     - реализовать контроллеры/сервисы под ТЗ (создание обращений, маршрутизация по категориям/статусам, админские операции).

3. **Безопасность и инфраструктура**
   - CORS, rate limiting, защита от брутфорса и др. пока не настроены.
   - Роли и права доступа (гражданин / администратор) не реализованы — JWT хранит только `Id` и `PhoneNumber`.

4. **AI и аналитика**
   - Модули NLP/STT/CV, определение приоритетов и массовых проблем сейчас отсутствуют.
   - Тепловые карты и аналитические отчёты пока не реализованы (требуют сначала полноценной модели обращений).

Этот документ отражает текущее состояние backend-части и основные направления для её дальнейшего развития в соответствии с ТЗ проекта «ГЛАС».

---

## 7. Быстрый старт и использование

### 7.1. Локальный запуск

1. Установить:
   - .NET SDK 9.x;
   - PostgreSQL 14+.
2. Создать БД (по умолчанию `glas_db`) и пользователя (`postgres` / пароль как в `appsettings.json` или своём connection string).
3. Проверить/изменить строку подключения:
   - либо добавить `ConnectionStrings:DefaultConnection` в `appsettings.json`;
   - либо отредактировать fallback в `Program.cs`.
4. Создать миграции, если их ещё нет:

```bash
cd GLAS_Server
dotnet ef migrations add InitialCreate
dotnet ef database update
```

5. Запустить сервер:

```bash
cd GLAS_Server
dotnet run
```

Сервер будет доступен по адресу: `http://localhost:5024`.  
В dev-режиме документация API доступна по `http://localhost:5024/swagger`.

### 7.2. Тестовый сценарий восстановления пароля (Windows)

В папке `GLAS_Server` есть скрипт `run_all_tests.bat`, который:

1. Запускает сервер `dotnet run`.
2. Регистрирует тестового пользователя по телефону `+79991234567`.
3. Запрашивает SMS-код восстановления пароля.
4. Пытается сменить пароль на `NewPassword123` (используя код `123456`).
5. Пробует залогиниться с новым паролем.

Скрипт использует `curl` и ожидает, что сервер слушает `http://localhost:5024`.  
Путь к проекту зашит в строке `cd /d "c:\Glas\GLAS-smart-civilian-AI-assistant-for-cities\GLAS_Server"` — при необходимости его нужно скорректировать под свою среду.

### 7.3. Использование бэкенда с фронтенда

При разработке фронтенда предполагается, что:

- базовый URL API: `http://localhost:5024/api` (или другой, если переопределён прокси/окружение);
- для аутентификации используется:
  - `POST /api/user/login` — получение JWT;
  - `Authorization: Bearer <token>` — во всех защищённых запросах.

Во фронтенде (GLAS_Client) базовый адрес задаётся через:

```bash
VITE_API_BASE_URL=http://localhost:5024/api
```

и читается в коде как `import.meta.env.VITE_API_BASE_URL`.

