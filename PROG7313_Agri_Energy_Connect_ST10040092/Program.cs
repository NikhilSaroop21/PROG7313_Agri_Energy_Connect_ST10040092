using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PROG7313_Agri_Energy_Connect_ST10040092.Data;
using PROG7313_Agri_Energy_Connect_ST10040092.Models;

var builder = WebApplication.CreateBuilder(args);

// Get the connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Configure Entity Framework and SQL Server
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

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Seed roles, users, and farmer products
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

    // Seed employee
    var employeeEmail = "employee@email.com";
    var employeePassword = "Pa$$w0rd!";
    var employeeUser = await userManager.FindByEmailAsync(employeeEmail);
    if (employeeUser == null)
    {
        var newEmployee = new IdentityUser { UserName = employeeEmail, Email = employeeEmail };
        await userManager.CreateAsync(newEmployee, employeePassword);
        await userManager.AddToRoleAsync(newEmployee, "Employee");
    }

    // Seed farmer 1
    var farmerEmail = "farmer@email.com";
    var farmerPassword = "Pa$$w0rd!";
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

    // Seed farmer 2
    var secondFarmerEmail = "farmer2@email.com";
    var secondFarmerPassword = "Pa$$w0rd!";
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

    // Seed fruit products for farmer 1
    var seededFarmer = await db.Farmers.FirstOrDefaultAsync(f => f.Email == farmerEmail);
    if (seededFarmer != null)
    {
        var existingProducts = db.Products.Where(p => p.FarmerId == seededFarmer.Id);
        db.Products.RemoveRange(existingProducts);
        await db.SaveChangesAsync();

        db.Products.AddRange(
            new Products
            {
                Name = "Golden Apples",
                Type = "Fruit",
                ProductionDate = new DateTime(2024, 9, 1),
                ImagePath = "/images/products/apples.jpg",
                FarmerId = seededFarmer.Id
            },
            new Products
            {
                Name = "Fresh Oranges",
                Type = "Fruit",
                ProductionDate = new DateTime(2024, 9, 10),
                ImagePath = "/images/products/oranges.jpg",
                FarmerId = seededFarmer.Id
            },
            new Products
            {
                Name = "Sweet Mangoes",
                Type = "Fruit",
                ProductionDate = new DateTime(2024, 9, 15),
                ImagePath = "/images/products/mangoes.jpg",
                FarmerId = seededFarmer.Id
            }
        );

        await db.SaveChangesAsync();
    }
}

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
