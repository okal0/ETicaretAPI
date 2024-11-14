using ETicaretAPI.Application.Abstractions.Token;
using ETicaretAPI.Infrastructure.Services.Token;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfraServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler, TokenHandler>();
        }

    }
}
