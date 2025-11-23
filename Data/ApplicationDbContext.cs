using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EcomWebsite.Models;

namespace EcomWebsite.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Products> Product { get; set; }
    public DbSet<CartItems> UserCart { get; set; }
    public DbSet<UserCredentials> UserCredential {get; set;}

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
