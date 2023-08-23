namespace API_Oficina.Models
{
    public class WorkType
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
