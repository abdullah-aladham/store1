namespace store1.Models.MViews
{
    public class TopViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string type { get; set; }
        public double price { get; set; }
        public virtual Products product { get; set; }
    }
}
