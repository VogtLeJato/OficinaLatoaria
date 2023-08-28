using Microsoft.EntityFrameworkCore;

namespace API_Oficina.Models;
    public class OficinaContext : DbContext
    {
        public OficinaContext(DbContextOptions<OficinaContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Material> Materials { get; set; } = null!;
        public DbSet<BuyedMaterial> BuyedMaterials { get; set; } = null!;
        public DbSet<Work> Works { get; set; } = null!;
        public DbSet<WorkType> WorkTypes { get; set; } = null!;
}