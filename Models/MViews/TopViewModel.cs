using System.ComponentModel;

namespace store1.Models.MViews
{
    public class TopViewModel
    {
       /* CustomerId =
        CustomerName
        CustomerType
        productId = */
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerType { get; set; } = "Top";
       
        public virtual Products product { get; set; }
        public int productId { get; set; }
        public string ProductName { get; set; }
        public double wholesalePrice  { get; set; }
    }
}
