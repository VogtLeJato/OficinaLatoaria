namespace API_Oficina.Models
{
    public class Car
    {
        public long Id {  get; set; }
        public String? Model { get; set; }
        public String? License_Plate { get; set; }
        public String? Color { get; set; }
        public int Year { get; set; }
    }
}
