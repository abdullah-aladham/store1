using store1.Enums;

namespace store1.Models.Fetches
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CustomerType type { get; set; }
        public List<Products> Products { get; set; }
    }
}
