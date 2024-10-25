using ETicaretAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Contexts
{
    public class ETicaretAPIDbContext : DbContext
    {
        public ETicaretAPIDbContext(DbContextOptions options) : base(options) {
        }   

        public DbSet<Product> Products_k { get; set; }
        public DbSet<Order> Orders_k { get; set; }
        public DbSet<Customer> Customers_k { get; set; }    


    }

   
}
