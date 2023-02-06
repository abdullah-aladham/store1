namespace store1.Models.MViews
{
    public class RegularCustomerViewModel 
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Customertype { get; set; } = "Regular";

        public virtual Products product { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double price { get; set; }
        public virtual Customer Customer { get; set; }

    }
}
