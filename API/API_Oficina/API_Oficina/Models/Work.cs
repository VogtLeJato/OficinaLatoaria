namespace API_Oficina.Models
{
    public class Work
    {
        public int Id { get; set; }
        public WorkType? Type { get; set; }
        public List<BuyedMaterial>? UsedMaterials { get; set;}
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set;}
        public bool IsConcluded { get; set; }
        public long LaborPrice { get; set; }
        public long CurrentPrice
        {
            get
            {
                if (UsedMaterials is not null)
                {
                    return UsedMaterials.Sum(usedMaterial => usedMaterial.PricePayed) + LaborPrice;
                }
                else
                {
                    return LaborPrice;
                }
            }
        }
    }
}
