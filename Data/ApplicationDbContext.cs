using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass6.Mvc.Models;

namespace ProgrammingClass6.Mvc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

      

        public DbSet<ProductType> ProductTypes { get; set; }

        public DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }

        public DbSet<Manufacture> Manufactures { get; set; }

        public DbSet<ProductTypeSize> ProductTypeSizes { get; set; }

        public DbSet<ProductTypeColor> ProductTypeColors { get; set; }

        public DbSet<Size> Sizes { get; set; }

        public DbSet<Color> Colors { get; set; }

  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ProductTypeSize>()
                .HasKey(pts => new { pts.ProductTypeId, pts.SizeId });
            builder.Entity<ProductTypeColor>()
                .HasKey(pts => new { pts.ProductTypeId, pts.ColorId });

        }
       
    }
}