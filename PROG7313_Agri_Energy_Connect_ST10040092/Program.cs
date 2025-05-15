using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PROG7313_Agri_Energy_Connect_ST10040092.Data;
using PROG7313_Agri_Energy_Connect_ST10040092.Models;

var builder = WebApplication.CreateBuilder(args);

//  Get the connection string from appsettings.json or throw an exception if missing
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");


//  Register the application's DbContext with SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Configure Identity with roles
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>();
//  Add MVC pattern support

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Seed roles, users, and products
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
    var db = services.GetRequiredService<ApplicationDbContext>();

    string[] roles = { "Farmer", "Employee" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    // Seed Employee
    var employeeEmail = "employee@email.com";
    var employeePassword = "EmpSecurePa$$!";
    var employeeUser = await userManager.FindByEmailAsync(employeeEmail);
    if (employeeUser == null)
    {
        var newEmployee = new IdentityUser { UserName = employeeEmail, Email = employeeEmail };
        await userManager.CreateAsync(newEmployee, employeePassword);
        await userManager.AddToRoleAsync(newEmployee, "Employee");
    }

    // Seed Farmer 1
    var farmerEmail = "farmer@email.com";
    var farmerPassword = "N3wSecurePa$$1!";
    var farmerUser = await userManager.FindByEmailAsync(farmerEmail);
    if (farmerUser == null)
    {
        var newFarmer = new IdentityUser { UserName = farmerEmail, Email = farmerEmail };
        await userManager.CreateAsync(newFarmer, farmerPassword);
        await userManager.AddToRoleAsync(newFarmer, "Farmer");

        db.Farmers.Add(new Farmer
        {
            Name = "Test Farmer",
            Email = farmerEmail,
            UserId = newFarmer.Id
        });

        await db.SaveChangesAsync();
    }

    // Seed Farmer 2
    var secondFarmerEmail = "farmer2@email.com";
    var secondFarmerPassword = "N3wSecurePa$$2!";
    var secondFarmerUser = await userManager.FindByEmailAsync(secondFarmerEmail);
    if (secondFarmerUser == null)
    {
        var newFarmer2 = new IdentityUser { UserName = secondFarmerEmail, Email = secondFarmerEmail };
        await userManager.CreateAsync(newFarmer2, secondFarmerPassword);
        await userManager.AddToRoleAsync(newFarmer2, "Farmer");

        db.Farmers.Add(new Farmer
        {
            Name = "Second Farmer",
            Email = secondFarmerEmail,
            UserId = newFarmer2.Id
        });

        await db.SaveChangesAsync();
    }

    // Seed products for Farmer 1
    var seededFarmer1 = await db.Farmers.FirstOrDefaultAsync(f => f.Email == farmerEmail);
    if (seededFarmer1 != null)
    {
        var existingProducts = db.Products.Where(p => p.FarmerId == seededFarmer1.Id);
        db.Products.RemoveRange(existingProducts);
        await db.SaveChangesAsync();

        db.Products.AddRange(
            new Products
            {
                Name = "Golden Apples",
                Type = "Fruit",
                ProductionDate = new DateTime(2025, 9, 1),
                ImagePath = "/images/products/apples.jpg",
                FarmerId = seededFarmer1.Id
            },
            new Products
            {
                Name = "Fresh Oranges",
                Type = "Fruit",
                ProductionDate = new DateTime(2025, 9, 10),
                ImagePath = "/images/products/oranges.jpg",
                FarmerId = seededFarmer1.Id
            },
            new Products
            {
                Name = "Sweet Mangoes",
                Type = "Fruit",
                ProductionDate = new DateTime(2025, 9, 15),
                ImagePath = "/images/products/mangoes.jpg",
                FarmerId = seededFarmer1.Id
            }
        );

        await db.SaveChangesAsync();
    }

    // ✅ Seed products for Farmer 2
    var seededFarmer2 = await db.Farmers.FirstOrDefaultAsync(f => f.Email == secondFarmerEmail);
    if (seededFarmer2 != null)
    {
        var existingProducts = db.Products.Where(p => p.FarmerId == seededFarmer2.Id);
        db.Products.RemoveRange(existingProducts);
        await db.SaveChangesAsync();

        db.Products.AddRange(
            new Products
            {
                Name = "Organic Carrots",
                Type = "Vegetable",
                ProductionDate = new DateTime(2025, 8, 20),
                ImagePath = "/images/products/carrots.jpg",
                FarmerId = seededFarmer2.Id
            },
            new Products
            {
                Name = "Green Spinach",
                Type = "Vegetable",
                ProductionDate = new DateTime(2025, 8, 25),
                ImagePath = "/images/products/spinach.jpg",
                FarmerId = seededFarmer2.Id
            },
            new Products
            {
                Name = "Cherry Tomatoes",
                Type = "Vegetable",
                ProductionDate = new DateTime(2025, 9, 2),
                ImagePath = "/images/products/tomatoes.jpg",
                FarmerId = seededFarmer2.Id
            }
        );

        await db.SaveChangesAsync();
    }
}

// Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
