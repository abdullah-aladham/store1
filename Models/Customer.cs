using Castle.Components.DictionaryAdapter;
using Microsoft.EntityFrameworkCore.Infrastructure;
using store1.Enums;
using store1.Models.Relations;

namespace store1.Models
{
    public class Customer
    {

        
        public int Id { get; set; }
        public string Name { get; set; }
      public string type { get; set; }
        public  virtual ICollection<CustomerProducts> Customer_Products { get;  set; }

        
    }
}
