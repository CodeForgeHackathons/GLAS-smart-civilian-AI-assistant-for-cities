
namespace GLAS_Server.Services.Interfaces
{
    public interface IJwtTokenProvider
    {
        string GenerateToken(uint userId, string phoneNumber);
    }

}
