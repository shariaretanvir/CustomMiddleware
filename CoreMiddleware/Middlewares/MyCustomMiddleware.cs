using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMiddleware.Middlewares
{
    public class MyCustomMiddleware
    {
        private readonly RequestDelegate next;

        public MyCustomMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context) {
            await context.Response.WriteAsync("In custom middleware\n");
            await next.Invoke(context);
        }
    }
}
