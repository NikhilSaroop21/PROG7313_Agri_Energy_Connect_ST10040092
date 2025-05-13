using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PROG7313_Agri_Energy_Connect_ST10040092.Data;
using PROG7313_Agri_Energy_Connect_ST10040092.Models;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false; 
})
    .AddRoles<IdentityRole>() 
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();


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


    var employeeEmail = "employee@email.com";
    var employeePassword = "Pa$$w0rd!";
    var employeeUser = await userManager.FindByEmailAsync(employeeEmail);
    if (employeeUser == null)
    {
        var newEmployee = new IdentityUser { UserName = employeeEmail, Email = employeeEmail };
        await userManager.CreateAsync(newEmployee, employeePassword);
        await userManager.AddToRoleAsync(newEmployee, "Employee");
    }


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
