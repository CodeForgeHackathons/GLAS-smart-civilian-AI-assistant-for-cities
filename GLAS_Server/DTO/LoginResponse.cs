namespace GLAS_Server.DTO
{
    public class LoginResponse
    {
        public uint AccountID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string BirthDate { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
