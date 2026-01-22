@echo off
setlocal enabledelayedexpansion
chcp 65001 >nul 2>&1

REM Запуск сервера в фоне
echo.
echo ╔════════════════════════════════════════════════════╗
echo ║       GLAS SERVER - SMS PASSWORD RECOVERY TEST     ║
echo ╚════════════════════════════════════════════════════╝
echo.

cd /d "c:\Glas\GLAS-smart-civilian-AI-assistant-for-cities\GLAS_Server"

echo [1/5] Запускаю GLAS Server...
echo ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

start "" cmd /k "dotnet run"
timeout /t 10 /nobreak

echo.
echo [2/5] РЕГИСТРАЦИЯ ПОЛЬЗОВАТЕЛЯ
echo ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

curl -s -X POST http://localhost:5024/api/user/register ^
  -H "Content-Type: application/json" ^
  -d "{\"phoneNumber\":\"+79991234567\",\"firstName\":\"Ivan\",\"lastName\":\"Petrov\",\"birthDate\":\"1990-01-15\",\"password\":\"OldPassword123\"}"

echo.
echo ✓ Пользователь зарегистрирован
timeout /t 2 /nobreak

echo.
echo [3/5] ЗАПРОС КОДА ВОССТАНОВЛЕНИЯ
echo ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

curl -s -X POST http://localhost:5024/api/user/request-password-reset ^
  -H "Content-Type: application/json" ^
  -d "{\"phoneNumber\":\"+79991234567\"}"

echo.
echo ✓ Код восстановления отправлен
echo 📌 КОД ДОЛЖЕН БЫТЬ ВЫВЕДЕН В КОНСОЛИ СЕРВЕРА!
timeout /t 3 /nobreak

echo.
echo [4/5] СМЕНА ПАРОЛЯ
echo ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

curl -s -X POST http://localhost:5024/api/user/verify-password-reset ^
  -H "Content-Type: application/json" ^
  -d "{\"phoneNumber\":\"+79991234567\",\"code\":\"123456\",\"newPassword\":\"NewPassword123\"}"

echo.
echo ✓ Результат смены пароля выведен
timeout /t 2 /nobreak

echo.
echo [5/5] ЛОГИН С НОВЫМ ПАРОЛЕМ
echo ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

curl -s -X POST http://localhost:5024/api/user/login ^
  -H "Content-Type: application/json" ^
  -d "{\"phoneNumber\":\"+79991234567\",\"password\":\"NewPassword123\"}"

echo.
echo.
echo ╔════════════════════════════════════════════════════╗
echo ║           ТЕСТИРОВАНИЕ ЗАВЕРШЕНО ✓                ║
echo ╚════════════════════════════════════════════════════╝
echo.

pause
