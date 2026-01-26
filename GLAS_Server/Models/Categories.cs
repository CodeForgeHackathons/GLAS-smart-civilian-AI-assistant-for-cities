namespace GLAS_Server.Models
{
    public class Categories
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Department { get; set; }
        public uint Priority { get; set; } = 1;

    }
}

