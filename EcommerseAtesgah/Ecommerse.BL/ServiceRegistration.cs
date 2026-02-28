using Ecommerse.BL.Service.Implementation.Product;
using Ecommerse.BL.Service.Interface.Product;
using Ecommerse.BL.Services.Implements;
using Ecommerse.BL.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse.BL
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            return services;
        }
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ServiceRegistration));
            return services;
        }
    }
}
