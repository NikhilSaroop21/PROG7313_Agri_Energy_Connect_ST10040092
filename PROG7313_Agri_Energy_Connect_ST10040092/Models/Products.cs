namespace PROG7313_Agri_Energy_Connect_ST10040092.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime ProductionDate { get; set; }
        public string ImagePath { get; set; }

        public int FarmerId { get; set; }
        public Farmer Farmer { get; set; }
    }
}
