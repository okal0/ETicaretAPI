using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Concrete
{
    public class ProductService : IProductService
    {

        public List<Product> GetProducts() => new()
       {
           new() {Id = Guid.NewGuid(), Name = "Product1", Price = 100, Stock = 10, },
           new() {Id = Guid.NewGuid(), Name = "Product13", Price = 113, Stock = 10, },
           new() {Id = Guid.NewGuid(), Name = "Product14", Price = 114, Stock = 10 },

       };
    }
}
