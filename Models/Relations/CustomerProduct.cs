namespace store1.Models.Relations
{
    public class CustomerProduct
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer customer { get; set; }
        public int ProductId { get; set; }
        public Products product { get; set; }
    }
}
