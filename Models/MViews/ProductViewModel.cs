using System.ComponentModel.DataAnnotations;

namespace store1.Models.MViews
{
    public class ProductViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double wholesalePrice { get; set; }
        public double price { get; set; }
    }
}
