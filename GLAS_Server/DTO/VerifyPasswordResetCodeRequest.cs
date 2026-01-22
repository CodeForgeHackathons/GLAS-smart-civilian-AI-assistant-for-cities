namespace GLAS_Server.DTO
{
    public class VerifyPasswordResetCodeRequest
    {
        public string PhoneNumber { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
    }
}
