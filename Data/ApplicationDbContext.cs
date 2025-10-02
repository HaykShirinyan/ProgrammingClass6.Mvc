using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass6.Mvc.Models;

namespace ProgrammingClass6.Mvc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProductType> ProductTypes { get; set; }

        public DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }

        public DbSet<Manufacture> Manufactures { get; set; }

        public DbSet<ProductTypeSize> ProductTypeSizes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ProductTypeSize>()
                .HasKey(pts => new { pts.ProductTypeId, pts.SizeId });
            
        }
    }
}