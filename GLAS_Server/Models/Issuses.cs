namespace GLAS_Server.Models
{

    public class Issuses
    {

        public uint Id { get; set; }
        public uint UserID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public uint CategoryID { get; set; }
        public uint StatusID { get; set; }
        public string AssignedDepartment { get; set; }

        public float Latitude { get; set; } = 0.0;
        public float Longitude { get; set; } = 0.0;
        public string Address { get; set; }

        public bool IsAnonymous { get; set; } = false;
        public string AnonymousToken { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

    }

}
