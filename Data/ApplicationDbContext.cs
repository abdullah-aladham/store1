using Microsoft.EntityFrameworkCore;
using store1.Models;
using store1.Models.Relations;

namespace store1.Data
{
    public class ApplicationDbContext :DbContext
    {
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<Products>()
        //         .HasMany(p => p.Customers).WithMany(c => c.Products)
        //         .UsingEntity<CustomerProduct>(j => j.HasOne(cp => cp.Products)
        //         .WithMany(t =>)
        //}
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Products> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseMySQL("server=localhost;database=store;username=root;password=HelloWorld-1516!");
        }
       
    }
}
