using System.ComponentModel.DataAnnotations;

namespace store1.Models.Fetches
{
    public class ProductViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float wholesalePrice { get; set; }
        public float price { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}
