using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.SpaServices.Webpack;
using NSwag.AspNetCore;

namespace Utils.MiddlewareExtensionMethods.Extensions
{
  

    public static class MiddlewareExtensionMethods
    {
        public static void UseExceptionMiddleware(this IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                        if (exceptionHandlerFeature != null)
                        {
                            var error = exceptionHandlerFeature.Error;
                        }

                        context.Response.StatusCode = 500;
                        //context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync("An unexpected fault happened. Try again later...");
                        //await context.Response.WriteAsync(exceptionHandlerFeature.Error.Message);
                    });
                });
            }
        }
        public static void UseWebpackMiddleware(this IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true,
                    ReactHotModuleReplacement = true
                });
            }
        }
        public static void UseSwaggerMiddleware(this IApplicationBuilder app, Assembly assembly, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwaggerUi3WithApiExplorer(config =>
                {
                    config.GeneratorSettings.DefaultPropertyNameHandling = NJsonSchema.PropertyNameHandling.CamelCase;
                });
            }
        }
    }
}