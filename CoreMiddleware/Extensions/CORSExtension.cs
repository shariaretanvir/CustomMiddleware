using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMiddleware.Extensions
{
    public static class CORSExtension
    {
        public static void UseCustomCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });

                options.AddPolicy(name: "CorsPolicy2", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });
        }
    }
}
