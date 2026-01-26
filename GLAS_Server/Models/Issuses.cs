namespace GLAS_Server.Models
{

    public class Issuses
    {

        public uint Id { get; set; }
        public uint UserID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public uint CategoryID { get; set; }
        public uint StatusID { get; set; }
        public string AssignedDepartment { get; set; } = string.Empty;

        public float Latitude { get; set; } = 0;
        public float Longitude { get; set; } = 0;
        public string Address { get; set; } = string.Empty;

        public bool IsAnonymous { get; set; } = false;
        public string AnonymousToken { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

    }

}
