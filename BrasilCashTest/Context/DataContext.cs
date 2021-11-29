using BrasilCashTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BrasilCashTest.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) { }


        public virtual DbSet<Customer> Customer { get; set; }

        public virtual DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Customer>(entity =>)
        }


    }
}
