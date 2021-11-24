using CoreMiddleware.Extensions;
using CoreMiddleware.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMiddleware
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<FactoryBasedCustomMiddleware>();
            services.UseCustomCors();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CoreMiddleware", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CoreMiddleware v1"));
            }
            //app.UseHsts();
            app.UseCustomException();
            app.UseHttpsRedirection();
            //app.UseStaticFiles();
            app.UseRouting();
            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            //add custom middleware

            app.Use(async (contect, next) =>
            {
                await contect.Response.WriteAsync("Use middleware 1 start\n");
                await next.Invoke();
                await contect.Response.WriteAsync("Use middleware 1 end\n");
            });
            app.UseHeaderExtension();
            app.UseCustomMiddleware();
            app.UseFactoryBasedCustomMiddleware();
            //app.Map("/getdata", builder =>
            //{
            //    builder.Use(async (context, next) =>
            //    {
            //        await context.Response.WriteAsync("Map middleware start\n");
            //        await next.Invoke();
            //        await context.Response.WriteAsync("Map middleware end\n");
            //    });
            //    builder.Run(async (context) =>
            //    {
            //        await context.Response.WriteAsync("Map Run middleware\n");
            //    });
            //});

            //app.MapWhen(context => context.Request.Query.ContainsKey("token"), builder =>
            //{
            //    builder.Use(async (context, next) =>
            //    {
            //        await context.Response.WriteAsync("Use map start\n");
            //        await next.Invoke();
            //        await context.Response.WriteAsync("use map end\n");
            //    });
            //    builder.Run(async context =>
            //    {
            //        await context.Response.WriteAsync("use map run executes");
            //    });
            //});

            //app.Use(async (context, next) => {
            //    await context.Response.WriteAsync("Use middleware 2 start\n");
            //    await next.Invoke();
            //    await context.Response.WriteAsync("Use middleware 2 end\n");
            //});

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Run middleware\n");
            });

            //app.Use(async (context, next) => {
            //    await context.Response.WriteAsync("Use middleware 3 start\n");
            //    await next.Invoke();
            //    await context.Response.WriteAsync("Use middleware 3 end\n");
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
