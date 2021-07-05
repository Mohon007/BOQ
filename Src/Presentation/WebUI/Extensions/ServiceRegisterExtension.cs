using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Extensions
{
    public static class ServiceRegisterExtension
    {
        public static IServiceCollection AddServiceRegisterExtensionMethod(this IServiceCollection services, IConfiguration config)
        {
            return services;
        }
    }
}
