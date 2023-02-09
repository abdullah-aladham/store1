using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using store1.Models.Relations;
using System.ComponentModel.DataAnnotations.Schema;

namespace store1.Models
{
    public class Products
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public double wholesalePrice { get; set; }

        public double price { get; set; }
        public virtual ICollection<CustomerProducts> Customers_Products{ get; set;}
        
    }
}
