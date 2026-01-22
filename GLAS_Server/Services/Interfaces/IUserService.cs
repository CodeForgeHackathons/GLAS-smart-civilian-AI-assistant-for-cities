using GLAS_Server.DTO;

namespace GLAS_Server.Services.Interfaces
{
    public interface IUserService
    {

        Task<(bool Success, string Message)> RegisterAsync(RegisterRequest request);


        Task<LoginResponse?> LoginAsync(LoginRequest request);


        Task<UserProfile?> GetProfileAsync(uint Id);


        Task<(bool Success, string Message)> UpdateProfileAsync(UserProfile request);


        Task<(bool Success, string Message)> ChangePasswordAsync(ChangePasswordRequest request);


        /// <summary>
        /// Запрашивает отправку кода восстановления пароля на номер телефона
        /// </summary>
        Task<(bool Success, string Message)> RequestPasswordResetAsync(string phoneNumber);


        /// <summary>
        /// Проверяет код восстановления пароля и меняет пароль
        /// </summary>
        Task<(bool Success, string Message)> VerifyAndResetPasswordAsync(VerifyPasswordResetCodeRequest request);


        //       Task<bool> DeleteUserAsync(int userId);
    }
}

