namespace store1.Models.MViews
{
    public class CustomerProductViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int ProductId { get; set; }
        
         public virtual Products Product { get; set; }
    }
}
