using BrasilCashTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BrasilCashTest.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        public virtual DbSet<Customer> Customer { get; set; }

        public virtual DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Id)
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("NEWID()");
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Id)
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("NEWID()");
            });
        }


    }
}
