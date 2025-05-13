using System.ComponentModel.DataAnnotations;

namespace PROG7313_Agri_Energy_Connect_ST10040092.Models
{
    public class FarmerViewModel
    {
        [Required]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
