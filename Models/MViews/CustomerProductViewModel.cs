namespace store1.Models.MViews
{
    public class CustomerProductViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int ProductId { get; set; }
        
         public virtual Products Product { get; set; }
        public CustomerProductViewModel(int id, int customerId, int productId)
        {
            Id = id;
            CustomerId = customerId;
            ProductId = productId;
        }
        public CustomerProductViewModel()
        {

        }
    }
}
