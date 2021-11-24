using CoreMiddleware.Middlewares;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMiddleware.Extensions
{
    public static class MiddlwareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder app)
            => app.UseMiddleware<MyCustomMiddleware>();

        public static IApplicationBuilder UseFactoryBasedCustomMiddleware(this IApplicationBuilder app)
            => app.UseMiddleware<FactoryBasedCustomMiddleware>();

        public static IApplicationBuilder UseCustomException(this IApplicationBuilder app) =>
            app.UseMiddleware<ExceptionMiddleware>();
    }
}
