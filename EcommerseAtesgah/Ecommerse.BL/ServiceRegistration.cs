using Ecommerse.BL.ExternalServices.Abstractions;
using Ecommerse.BL.ExternalServices.Implements;
using Ecommerse.BL.Service.Implementation;
using Ecommerse.BL.Service.Interface;
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

        public static IServiceCollection AddServices(this IServiceCollection services)
        {

            
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtTokenHandler, JwtTokenHandler>();
           
            return services;
        }


       

        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ServiceRegistration));
            return services;
        }

    }
}
