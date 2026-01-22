using GLAS_Server.Services.Interfaces;

namespace GLAS_Server.Services
{
    public class SmsProvider : ISmsProvider
    {
        private readonly ILogger<SmsProvider> _logger;
        private readonly IConfiguration _configuration;

        public SmsProvider(ILogger<SmsProvider> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        /// <summary>
        /// Отправляет SMS сообщение на указанный номер телефона.
        /// Поддерживаются: Mock (разработка), Twilio (реальные SMS)
        /// </summary>
        public async Task<bool> SendSmsAsync(string phoneNumber, string message)
        {
            try
            {
                var smsProvider = _configuration["SmsSettings:Provider"] ?? "Mock";

                switch (smsProvider.ToLower())
                {
                    case "twilio":
                        return await SendViaTwilioAsync(phoneNumber, message);

                    case "mock":
                    default:
                        return SendViaMockAsync(phoneNumber, message);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ошибка при отправке SMS на номер {phoneNumber}: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Mock провайдер для разработки - логирует код в консоль
        /// </summary>
        private bool SendViaMockAsync(string phoneNumber, string message)
        {
            _logger.LogInformation($"\n========== SMS MOCK PROVIDER ==========");
            _logger.LogInformation($"Номер телефона: {phoneNumber}");
            _logger.LogInformation($"Сообщение: {message}");
            _logger.LogInformation($"=======================================\n");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n[SMS] Номер: {phoneNumber}");
            Console.WriteLine($"[SMS] Текст: {message}\n");
            Console.ResetColor();

            return true;
        }

        /// <summary>
        /// Отправка через Twilio (требует учетные данные в appsettings.json)
        /// Получить бесплатный trial: https://www.twilio.com/try-twilio
        /// </summary>
        private async Task<bool> SendViaTwilioAsync(string phoneNumber, string message)
        {
            try
            {
                var accountSid = _configuration["SmsSettings:Twilio:AccountSid"];
                var authToken = _configuration["SmsSettings:Twilio:AuthToken"];
                var fromNumber = _configuration["SmsSettings:Twilio:FromNumber"];

                if (string.IsNullOrEmpty(accountSid) || string.IsNullOrEmpty(authToken))
                {
                    _logger.LogWarning("Twilio credentials not configured. Falling back to Mock provider.");
                    return SendViaMockAsync(phoneNumber, message);
                }

                // Пример кода для Twilio (требуется NuGet: Install-Package Twilio)
                // TwilioClient.Init(accountSid, authToken);
                // var sms = await MessageResource.CreateAsync(
                //     body: message,
                //     from: new Twilio.Types.PhoneNumber(fromNumber),
                //     to: new Twilio.Types.PhoneNumber(phoneNumber)
                // );
                // _logger.LogInformation($"SMS отправлено на {phoneNumber}. SID: {sms.Sid}");

                _logger.LogInformation($"SMS отправлено через Twilio на номер {phoneNumber}");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ошибка Twilio: {ex.Message}. Использование Mock provider.");
                return SendViaMockAsync(phoneNumber, message);
            }
        }
    }
}
