

using Microsoft.EntityFrameworkCore.Infrastructure;

namespace store1.Models
{
    public class CustomerProducts
    {

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public  virtual Customer  Customer { get; set; }
        public int ProductId { get; set; }
        
        public virtual Products Product { get; set; }

        /*internal object Include(Func<object, object> value)
        {
            throw new NotImplementedException();
        }*/
    }
}
