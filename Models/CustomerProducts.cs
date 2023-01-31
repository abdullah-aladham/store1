

namespace store1.Models
{
    public class CustomerProducts
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer  Customer { get; set; }
        public int ProductId { get; set; }
        
        public Products Product { get; set; }
    }
}
