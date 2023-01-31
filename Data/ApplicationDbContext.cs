using Microsoft.EntityFrameworkCore;
using store1.Models;


namespace store1.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

       
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<CustomerProducts> Customer_Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseMySQL("server=localhost;database=store;username=root;password=HelloWorld-1516!");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerProducts>()
                .HasOne(c => c.Customer).
                WithMany(cp => cp.Customer_Products)
                .HasForeignKey(ci => ci.CustomerId);

            modelBuilder.Entity<CustomerProducts>()
               .HasOne(c => c.Product).
               WithMany(cp => cp.Customers_Products)
               .HasForeignKey(ci => ci.Id);
        }
       
    }
}
