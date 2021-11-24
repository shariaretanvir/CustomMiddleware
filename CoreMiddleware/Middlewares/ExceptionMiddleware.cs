using Microsoft.AspNetCore.Http;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoreMiddleware.Middlewares
{
    public class ExceptionMiddleware
    {
        public readonly RequestDelegate next;

        public ExceptionMiddleware(RequestDelegate next)=> this.next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception ex)
            {
                //context.Response.ContentType= "application/json";
                var result = JsonSerializer.Serialize(new
                {
                    statusCode = 400,
                    message = ex.Message
                });
                await context.Response.WriteAsync(result);
            }
        }
    }
}
