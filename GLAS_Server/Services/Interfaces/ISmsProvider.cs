namespace GLAS_Server.Services.Interfaces
{
    public interface ISmsProvider
    {
        Task<bool> SendSmsAsync(string phoneNumber, string message);
    }
}
