using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass6.Mvc.Models;

namespace ProgrammingClass6.Mvc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<ProductType> ProductTypes { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
