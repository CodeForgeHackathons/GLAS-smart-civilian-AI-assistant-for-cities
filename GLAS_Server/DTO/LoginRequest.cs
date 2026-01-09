using System;

namespace GLAS_Server.DTO
{
    public class LoginRequest
    {
        public string PhoneNumber { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

    }
}
