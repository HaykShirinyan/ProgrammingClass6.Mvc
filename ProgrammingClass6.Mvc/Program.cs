using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=Index}/{id?}");
app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.EnsureCreated();

    if (!db.Manufacturers.Any())
    {
        var m1 = new Manufacturer { Name = "Samsung" };
        var m2 = new Manufacturer { Name = "Apple" };

        var c1 = new Category { Name = "Phones" };   
        var c2 = new Category { Name = "Tablets" };  

        var p1 = new Product { Name = "Galaxy S25", UnitPrice = 1200, Quantity = 10, Manufacturer = m1 };
        var p2 = new Product { Name = "iPad Pro", UnitPrice = 1500, Quantity = 5, Manufacturer = m2 };

        db.Manufacturers.AddRange(m1, m2);
        db.Categories.AddRange(c1, c2);
        db.Products.AddRange(p1, p2);
        db.ProductCategories.Add(new ProductCategory { Product = p1, Category = c1 });
        db.ProductCategories.Add(new ProductCategory { Product = p2, Category = c2 });

        db.SaveChanges();
    }
}

app.Run();
