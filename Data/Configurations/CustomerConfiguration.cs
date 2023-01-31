using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using store1.Enums;
using store1.Models;


namespace store1.Data.Configurations
{
    public class CustomerConfiguration
    { 
        //public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Customer> builder)
        //{
        //    throw new NotImplementedException();
        //}
        //public void Configure(EntityTypeBuilder<Customer> entity)
        //{
        //    entity.Property(t => t.type).HasConversion(c => c.ToString(), c => Enum.Parse<CustomerType>(c));
        //}
    }
}
