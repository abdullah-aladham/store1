using store1.Enums;
using store1.Models.Relations;

namespace store1.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
      public string type { get; set; }
        public  List<Products> Products { get; set; }
    }
}
