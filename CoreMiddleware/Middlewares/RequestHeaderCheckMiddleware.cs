using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoreMiddleware.Middlewares
{
    public class RequestHeaderCheckMiddleware
    {
        public readonly RequestDelegate next;

        public RequestHeaderCheckMiddleware(RequestDelegate next) => this.next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            //try {
                string header = context.Request.Headers.Where(t => t.Key == "Custom").FirstOrDefault().Value;
                if (header != "akash")
                {
                    throw new Exception("Header not found");                    
                }
                await next.Invoke(context);
            //}
            //catch (Exception ex) {
            //    var result = JsonSerializer.Serialize(new
            //    {
            //        statusCode = 404,
            //        message = ex.Message
            //    });
            //    //context.Response.Clear();
            //    await context.Response.WriteAsync(result);
            //}

        }
    }
}
