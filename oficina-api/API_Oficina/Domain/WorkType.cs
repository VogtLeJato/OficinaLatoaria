namespace API_Oficina.Domain
{
    public class WorkType
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
