
using GLAS_Server.DTO;

namespace GLAS_Server.Services.Interfaces
{
    public interface IUserService
    {

        Task<(bool Success, string Message)> RegisterAsync(RegisterRequest request);


        Task<UserProfile?> LoginAsync(LoginRequest request);


        Task<UserProfile?> GetProfileAsync(uint Id);


        Task<(bool Success, string Message)> UpdateProfileAsync(UserProfile request);


        //       Task<bool> DeleteUserAsync(int userId);
    }
}
