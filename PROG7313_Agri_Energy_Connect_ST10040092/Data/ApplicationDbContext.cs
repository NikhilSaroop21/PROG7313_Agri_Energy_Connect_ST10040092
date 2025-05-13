using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PROG7313_Agri_Energy_Connect_ST10040092.Models;

namespace PROG7313_Agri_Energy_Connect_ST10040092.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<Products> Products { get; set; }
    }
}
