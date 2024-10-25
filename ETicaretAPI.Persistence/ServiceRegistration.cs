using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Persistence.Concrete;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Drawing.Text;

namespace ETicaretAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
   
            services.AddSingleton<IProductService, ProductService>();

            services.AddDbContext<ETicaretAPIDbContext>(options => options.UseSqlServer(Config.GetConnectionString));   
        }
    }
}
