using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMiddleware.Middlewares
{
    public class FactoryBasedCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Factory based custom middleware.\n");
            await next.Invoke(context);
        }
    }
}
