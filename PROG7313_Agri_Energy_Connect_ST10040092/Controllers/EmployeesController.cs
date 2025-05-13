using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROG7313_Agri_Energy_Connect_ST10040092.Data;
using PROG7313_Agri_Energy_Connect_ST10040092.Models;

namespace PROG7313_Agri_Energy_Connect_ST10040092.Controllers
{
    // Restrict access to only users in the "Employee" role
    [Authorize(Roles = "Employee")]
        public class EmployeesController : Controller
        {
            private readonly ApplicationDbContext _context;
            private readonly UserManager<IdentityUser> _userManager;

        // Constructor with dependency injection for DB context and identity manager
        public EmployeesController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
            {
                _context = context;
                _userManager = userManager;
            }

            public IActionResult AddFarmer()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> AddFarmer(FarmerViewModel model)
            {
                if (!ModelState.IsValid)
                    return View(model);

                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Farmer");
                // Add corresponding Farmer profile to the database
                _context.Farmers.Add(new Farmer
                    {
                        Name = model.FullName,
                        Email = model.Email,
                        UserId = user.Id
                    });

                    await _context.SaveChangesAsync();
                    TempData["Success"] = " Account For Farmer  was created successfully.";
                    return RedirectToAction(nameof(AddFarmer));
                }

            // Handle validation errors returned by Identity
            foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);

                return View(model);
            }

            public async Task<IActionResult> ViewProducts()
            {
                var products = await _context.Products.Include(p => p.Farmer).ToListAsync();
                return View(products);
            }

            [HttpPost]
            public async Task<IActionResult> FilterProducts(string type, DateTime? fromDate, DateTime? toDate)
            {
                var query = _context.Products.Include(p => p.Farmer).AsQueryable();
            // Apply type filter if provided
            if (!string.IsNullOrEmpty(type))
                    query = query.Where(p => p.Type == type);

            // Apply date range filters
            if (fromDate.HasValue)
                    query = query.Where(p => p.ProductionDate >= fromDate);

                if (toDate.HasValue)
                    query = query.Where(p => p.ProductionDate <= toDate);

            // Return the filtered product list to the same View
            return View("ViewProducts", await query.ToListAsync());
            }
        }
    }

