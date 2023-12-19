using AssoSw.Lesson7.AspNetCoreWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AssoSw.Lesson7.AspNetCoreWebApi.Context
{
    public class WarehouseContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; } = null!;

        public DbSet<Order> Orders { get; set; } = null!;

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<OrderDetail> OrderDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // It would be a good idea to move the connection string to user secrets
            optionsBuilder
                .UseSqlServer("Data Source=localhost;Initial Catalog=CorsoAssoSW;User ID=devadmin;Password=devadmin;TrustServerCertificate=True");
        }
    }
}
