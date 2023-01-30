using store1.Models.Relations;

namespace store1.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float wholesalePrice { get; set; }
        public float price { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
