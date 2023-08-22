using Microsoft.EntityFrameworkCore;

namespace API_Oficina.Models;
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; } = null!;
}