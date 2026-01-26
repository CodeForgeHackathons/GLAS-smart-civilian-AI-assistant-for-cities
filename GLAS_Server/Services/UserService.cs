using GLAS_Server.Services.Interfaces;
using GLAS_Server.Data;
using GLAS_Server.DTO;
using Microsoft.EntityFrameworkCore;
using GLAS_Server.Models;
using System.Text.RegularExpressions;
namespace GLAS_Server.Services
{

    public class UserService : IUserService
    {
        private readonly AppDbContext _db;
        private readonly IJwtTokenProvider _jwtTokenProvider;
        private readonly ISmsProvider _smsProvider;
        private readonly ILogger<UserService> _logger;

        public UserService(AppDbContext db, IJwtTokenProvider jwtTokenProvider, ISmsProvider smsProvider, ILogger<UserService> logger)
        {

            _db = db;
            _jwtTokenProvider = jwtTokenProvider;
            _smsProvider = smsProvider;
            _logger = logger;

        }

        public async Task<UserProfile?> GetProfileAsync(uint id)
        {

            var user = await _db.Users.FirstOrDefaultAsync(user => user.Id == id);
            if (user == null)
                return null;

            var profileData = new UserProfile
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate,
            };
            return profileData;
        }
        //   public async Task<bool?> DeleteUserAsync(int userid) => false; //soon

        public async Task<(bool Success, string Message)> RegisterAsync(DTO.RegisterRequest request)
        {

            if (string.IsNullOrWhiteSpace(request.PhoneNumber) || string.IsNullOrWhiteSpace(request.FirstName) || string.IsNullOrWhiteSpace(request.LastName) || string.IsNullOrWhiteSpace(request.Password) || string.IsNullOrWhiteSpace(request.BirthDate))
                return (false, "Enter all lines");

            var exists = await _db.Users.AnyAsync(user => user.PhoneNumber == request.PhoneNumber);

            if (exists)
                return (false, "User already exists");

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = hashedPassword,
                BirthDate = request.BirthDate,
                PhoneNumber = request.PhoneNumber
            };
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return (Success: true, Message: "User registered!");


        }

        public async Task<LoginResponse?> LoginAsync(DTO.LoginRequest request)
        {

            if (string.IsNullOrWhiteSpace(request.PhoneNumber) || string.IsNullOrWhiteSpace(request.Password))
                return null;


            var user = await _db.Users.FirstOrDefaultAsync(u => u.PhoneNumber == request.PhoneNumber);
            if (user == null)
                return null;

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
                return null;

            var token = _jwtTokenProvider.GenerateToken(user.Id, user.PhoneNumber);

            var result_profile = new LoginResponse
            {
                AccountID = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                BirthDate = user.BirthDate,
                Token = token
            };
            return result_profile;

        }
        public async Task<(bool, string)> UpdateProfileAsync(DTO.UserProfile request)
        {

            var user = await _db.Users.FirstOrDefaultAsync(user => user.PhoneNumber == request.PhoneNumber);
            if (user == null)
                return (true, "User not found");

            user.BirthDate = request.BirthDate;
            //...
            await _db.SaveChangesAsync();
            return (true, "Profile updated!");

        }

        public async Task<(bool Success, string Message)> ChangePasswordAsync(DTO.ChangePasswordRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.PhoneNumber) || string.IsNullOrWhiteSpace(request.OldPassword) || string.IsNullOrWhiteSpace(request.NewPassword))
                return (false, "All fields are required");

            var user = await _db.Users.FirstOrDefaultAsync(u => u.PhoneNumber == request.PhoneNumber);
            if (user == null)
                return (false, "User not found");

            if (!BCrypt.Net.BCrypt.Verify(request.OldPassword, user.Password))
                return (false, "Old password is incorrect");

            if (request.NewPassword.Length < 8)
                return (false, "New password must be at least 8 characters long");

            if (!Regex.IsMatch(request.NewPassword, @"[a-zA-Z]") || !Regex.IsMatch(request.NewPassword, @"\d"))
                return (false, "New password must contain at least one letter and one number");

            var hashedNewPassword = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
            user.Password = hashedNewPassword;
            await _db.SaveChangesAsync();
            return (true, "Password changed successfully");
        }

        public async Task<(bool Success, string Message)> RequestPasswordResetAsync(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return (false, "Phone number is required");

            var user = await _db.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
            if (user == null)
                return (false, "User not found");

            // Генерируем 6-значный код
            var resetCode = GenerateRandomCode(6);

            // Сохраняем код с временем истечения (10 минут)
            user.PasswordResetOpt.PasswordResetCode = resetCode;
            user.PasswordResetOpt.PasswordResetCodeExpiry = DateTime.UtcNow.AddMinutes(10);

            await _db.SaveChangesAsync();

            // Отправляем SMS
            var message = $"Ваш код для восстановления пароля: {resetCode}. Код действителен 10 минут.";
            var smsSent = await _smsProvider.SendSmsAsync(phoneNumber, message);

            if (smsSent)
            {
                _logger.LogInformation($"Код восстановления пароля отправлен на номер {phoneNumber}");
                return (true, "Reset code sent to your phone");
            }
            else
            {
                // Удаляем код, если не удалось отправить SMS
                user.PasswordResetOpt.PasswordResetCode = null;
                user.PasswordResetOpt.PasswordResetCodeExpiry = null;
                await _db.SaveChangesAsync();

                _logger.LogError($"Не удалось отправить SMS на номер {phoneNumber}");
                return (false, "Failed to send SMS. Please try again");
            }
        }

        public async Task<(bool Success, string Message)> VerifyAndResetPasswordAsync(VerifyPasswordResetCodeRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.PhoneNumber) ||
                string.IsNullOrWhiteSpace(request.Code) ||
                string.IsNullOrWhiteSpace(request.NewPassword))
                return (false, "All fields are required");

            var user = await _db.Users.FirstOrDefaultAsync(u => u.PhoneNumber == request.PhoneNumber);
            if (user == null)
                return (false, "User not found");

            // Проверяем наличие кода
            if (string.IsNullOrEmpty(user.PasswordResetOpt.PasswordResetCode))
                return (false, "No password reset request found");

            // Проверяем срок действия кода
            if (user.PasswordResetOpt.PasswordResetCodeExpiry == null || DateTime.UtcNow > user.PasswordResetOpt.PasswordResetCodeExpiry)
            {
                user.PasswordResetOpt.PasswordResetCode = null;
                user.PasswordResetOpt.PasswordResetCodeExpiry = null;
                await _db.SaveChangesAsync();
                return (false, "Reset code has expired");
            }

            // Проверяем код
            if (user.PasswordResetOpt.PasswordResetCode != request.Code)
                return (false, "Invalid reset code");

            // Проверяем требования к новому паролю
            if (request.NewPassword.Length < 8)
                return (false, "New password must be at least 8 characters long");

            if (!Regex.IsMatch(request.NewPassword, @"[a-zA-Z]") || !Regex.IsMatch(request.NewPassword, @"\d"))
                return (false, "New password must contain at least one letter and one number");

            // Обновляем пароль
            var hashedNewPassword = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
            user.Password = hashedNewPassword;
            user.PasswordResetOpt.PasswordResetCode = null;
            user.PasswordResetOpt.PasswordResetCodeExpiry = null;

            await _db.SaveChangesAsync();

            _logger.LogInformation($"Пароль пользователя успешно изменен через SMS");
            return (true, "Password reset successfully");
        }

        /// <summary>
        /// Генерирует случайный цифровой код
        /// </summary>
        private string GenerateRandomCode(int length)
        {
            var random = new Random();
            var code = "";
            for (int i = 0; i < length; i++)
            {
                code += random.Next(0, 10).ToString();
            }
            return code;
        }


    }

}
