using CarBrandAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarBrandAPI.Data
{
    public class CarBrandContext : DbContext
    {
        public CarBrandContext(DbContextOptions<CarBrandContext> options) : base(options)
        {
        }

        public DbSet<CarBrand> CarBrands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarBrand>(entity =>
            {
                entity.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(p => p.Image)
                    .IsRequired();
            });
        }
    }
}
