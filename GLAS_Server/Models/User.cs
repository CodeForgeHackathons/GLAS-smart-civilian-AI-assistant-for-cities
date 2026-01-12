namespace GLAS_Server.Models
{
    public class User
    {
        public uint Id { get; set; }
        public uint AccountID { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string BirthDate { get; set; } = string.Empty;
    }
}
