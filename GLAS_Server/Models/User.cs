using System;

namespace GLAS_Server.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string BirthDate { get; set; } = string.Empty;
    }
}
