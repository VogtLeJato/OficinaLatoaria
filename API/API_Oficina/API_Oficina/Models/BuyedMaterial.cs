namespace API_Oficina.Models
{
    public class BuyedMaterial
    {
        public Material? Material { get; set; }
        public long PricePayed { get; set; }
        public DateTime? DateBuyed { get; set; }
    }
}
