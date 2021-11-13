using CoreMiddleware.Middlewares;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMiddleware.Extensions
{
    public static class HeaderMiddlewareExtension
    {
        public static IApplicationBuilder UseHeaderExtension(this IApplicationBuilder app) =>
            app.UseMiddleware<RequestHeaderCheckMiddleware>();
    }
}
