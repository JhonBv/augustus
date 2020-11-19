using amartindemo.Factories;
using amartindemo.proxy;
using amartindemo.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace amartindemo.Extensions
{
    /// <summary>
    /// Jhon B. It is a good practice to separate the DI from the Startup class so that it makes it easier to maintain the code.
    /// </summary>
    public static class AmartinDemoServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public static void ConfigureProxy(this IServiceCollection services)
        {
            services.AddSingleton<IProxyService, ProxyService>(x => new ProxyService(x.GetRequiredService<ITargetEndPoint>()));
            services.AddSingleton<ITargetEndPoint, TargetEndPoint>(x => new TargetEndPoint(new HttpClient(), x.GetRequiredService<ILogger<TargetEndPoint>>()));
        }
        public static void ConfigureFactories(this IServiceCollection services)
        {
            services.AddSingleton<IUserFactory, UserFactory>(x => new UserFactory(x.GetRequiredService<IProxyService>()));

        }
    }
}
