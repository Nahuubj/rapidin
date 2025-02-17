using Microsoft.EntityFrameworkCore;
using rapidin_api.Entities;
namespace rapidin_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Catalog> catalog { get; set; }
        public DbSet<Enterprise> enterprise { get; set; }
        public DbSet<Media> media { get; set; }
        public DbSet<Vehicle> vehicle { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
