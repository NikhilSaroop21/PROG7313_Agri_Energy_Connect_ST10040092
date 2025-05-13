using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROG7313_Agri_Energy_Connect_ST10040092.Data;
using PROG7313_Agri_Energy_Connect_ST10040092.Models;

namespace PROG7313_Agri_Energy_Connect_ST10040092.Controllers
{
  
        [Authorize(Roles = "Employee")]
        public class EmployeesController : Controller
        {
            private readonly ApplicationDbContext _context;
            private readonly UserManager<IdentityUser> _userManager;

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

                    _context.Farmers.Add(new Farmer
                    {
                        Name = model.FullName,
                        Email = model.Email,
                        UserId = user.Id
                    });

                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Farmer account created successfully.";
                    return RedirectToAction(nameof(AddFarmer));
                }

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

                if (!string.IsNullOrEmpty(type))
                    query = query.Where(p => p.Type == type);

                if (fromDate.HasValue)
                    query = query.Where(p => p.ProductionDate >= fromDate);

                if (toDate.HasValue)
                    query = query.Where(p => p.ProductionDate <= toDate);

                return View("ViewProducts", await query.ToListAsync());
            }
        }
    }

