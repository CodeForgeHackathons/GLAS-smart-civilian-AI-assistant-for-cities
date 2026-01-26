namespace GLAS_Server.Models
{

    public class PasswordResetOptions
    {
        public string? PasswordResetCode { get; set; }
        public DateTime? PasswordResetCodeExpiry { get; set; }
    }


}
