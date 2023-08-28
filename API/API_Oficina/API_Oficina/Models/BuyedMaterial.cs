namespace API_Oficina.Models
{
    public class BuyedMaterial
    {
        public int Id { get; set; }
        public Material? Material { get; set; }
        public long PricePayed { get; set; }
        public DateTime? DateBuyed { get; set; }
    }
}
