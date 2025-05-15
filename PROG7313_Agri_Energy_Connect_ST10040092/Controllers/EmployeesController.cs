using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROG7313_Agri_Energy_Connect_ST10040092.Data;
using PROG7313_Agri_Energy_Connect_ST10040092.Models;

namespace PROG7313_Agri_Energy_Connect_ST10040092.Controllers
{
    // Restrict access to this controller to users with the 'Employee' role

    [Authorize(Roles = "Employee")]
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        // Constructor with dependency injection for database context and identity manager

        public EmployeesController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // Display the Add Farmer form

        public IActionResult AddFarmer()
        {
            return View();
        }
        // List all products, optionally filtered by a specific farmer

        public async Task<IActionResult> Index(int? farmerId)
        {
            ViewBag.Farmers = await _context.Farmers.ToListAsync();
            // Base query includes associated farmer data

            var query = _context.Products
                .Include(p => p.Farmer)
                .AsQueryable();
            // Apply filter if a specific farmer is selected

            if (farmerId.HasValue)
            {
                query = query.Where(p => p.FarmerId == farmerId.Value);
                ViewBag.SelectedFarmer = await _context.Farmers.FindAsync(farmerId.Value);
            }

            var products = await query.ToListAsync();
            return View(products);
        }


        // Handle submission of new farmer registration
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

                _context.Farmers.Add(new Farmer
                {
                    Name = model.FullName,
                    Email = model.Email,
                    UserId = user.Id
                });

                await _context.SaveChangesAsync();
                TempData["Success"] = "Account for Farmer was created successfully.";
                return RedirectToAction(nameof(AddFarmer));
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return View(model);
        }
        // Filter products based on type, date range, and farmer

        public async Task<IActionResult> ViewProducts()
        {
            ViewBag.Farmers = await _context.Farmers.ToListAsync();
            var products = await _context.Products.Include(p => p.Farmer).ToListAsync();
            return View(products);
        }

        [HttpPost]
        public async Task<IActionResult> FilterProducts(string type, DateTime? fromDate, DateTime? toDate, int? farmerId)
        {
            var query = _context.Products.Include(p => p.Farmer).AsQueryable();

            if (!string.IsNullOrEmpty(type))
                query = query.Where(p => p.Type == type);

            if (fromDate.HasValue)
                query = query.Where(p => p.ProductionDate >= fromDate);

            if (toDate.HasValue)
                query = query.Where(p => p.ProductionDate <= toDate);

            if (farmerId.HasValue)
                query = query.Where(p => p.FarmerId == farmerId);
            // Reload farmers for dropdown in case of return

            ViewBag.Farmers = await _context.Farmers.ToListAsync();

            return View("ViewProducts", await query.ToListAsync());
        }

        //  View specific farmer's products
    
    }
}
