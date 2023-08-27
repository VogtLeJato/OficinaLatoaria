using Microsoft.EntityFrameworkCore;

namespace API_Oficina.Models;
    public class OficinaContext : DbContext
    {
        public OficinaContext(DbContextOptions<OficinaContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<Material> Materials { get; set; } = null!;
}