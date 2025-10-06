using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass6.Mvc.Models;

namespace ProgrammingClass6.Mvc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }

        public DbSet<ProductType> ProductTypes {  get; set; }     

        public DbSet<Product> Products { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<ProductColor> ProductColors { get; set;}   
        
        public DbSet<ProductSize> ProductSizes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .Entity<ProductCategory>()
                .HasKey(productCategory => new { productCategory.ProductId, productCategory.CategoryId });

            builder
                .Entity<ProductColor>()
                .HasKey(productColor => new { productColor.ProductId, productColor.ColorId });

            builder
                .Entity<ProductSize>()
                .HasKey(productSize => new { productSize.ProductId, productSize.SizeId });
        }
    }
}
