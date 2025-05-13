using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROG7313_Agri_Energy_Connect_ST10040092.Data;
using PROG7313_Agri_Energy_Connect_ST10040092.Models;

namespace PROG7313_Agri_Energy_Connect_ST10040092.Controllers
{
   
        [Authorize(Roles = "Farmer")]
        public class ProductsController : Controller
        {
            private readonly ApplicationDbContext _context;
            private readonly UserManager<IdentityUser> _userManager;
            private readonly IWebHostEnvironment _env;

            public ProductsController(ApplicationDbContext context, UserManager<IdentityUser> userManager, IWebHostEnvironment env)
            {
                _context = context;
                _userManager = userManager;
                _env = env;
            }

        // GET: List products created by the currently logged-in farmer
        public async Task<IActionResult> Index()
            {
                var userId = _userManager.GetUserId(User);
                var farmer = await _context.Farmers.FirstOrDefaultAsync(f => f.UserId == userId);

                if (farmer == null)
                    return NotFound("Farmer profile not found.");
            // Fetch only this farmer's products
            var products = await _context.Products
                    .Where(p => p.FarmerId == farmer.Id)
                    .ToListAsync();

                return View(products);
            }
        // GET: Show the Add Product form
        public IActionResult Create()
            {
                return View();
            }

        // POST: Handle form submission and save new product
        [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(Products product, IFormFile ImageFile)
            {
                var userId = _userManager.GetUserId(User);
                var farmer = await _context.Farmers.FirstOrDefaultAsync(f => f.UserId == userId);

                if (farmer == null)
                    return NotFound(" Profile not found for farmer.");


            // Handle image upload if provided
            if (ImageFile != null && ImageFile.Length > 0)
                {
                // Generate a unique file name and store it in the products image folder
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(ImageFile.FileName)}";
                    var filePath = Path.Combine(_env.WebRootPath, "images/products", fileName);
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageFile.CopyToAsync(stream);
                    }

                    product.ImagePath = $"/images/products/{fileName}";
                }
            // Link product to the current farmer
            product.FarmerId = farmer.Id;
            // Save to database
            _context.Products.Add(product);
                await _context.SaveChangesAsync();
            // Redirect to product list
            return RedirectToAction(nameof(Index));
            }
        }
    }

