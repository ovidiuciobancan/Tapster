using System.Linq;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Formatter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;


using NSwag.AspNetCore;

using Utils.Mapper.Extensions;
using Utils.Validation.Extensions;
using Utils.EntityFrameworkCore.Extensions;
using Tapster.Api.Code.OData;
using Tapster.BusinessLogic.Services;
using Tapster.DataAccess;
using Tapster.DataAccess.UnitsOfWork;
using Tapster.Common.UnitsOfWork;
using Tapster.Common.Services;
using System;

namespace Tapster.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("Default");

            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });

            services.AddOData();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddMvcCore(options =>
            {
                foreach (var outputFormatter in options.OutputFormatters.OfType<ODataOutputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
                {
                    outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
                foreach (var inputFormatter in options.InputFormatters.OfType<ODataInputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
                {
                    inputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
            });
            //.AddJsonOptions(options =>  options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());

            services.AddSwagger();

            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "http://localhost:5000";
                    options.RequireHttpsMetadata = false;
                    options.ApiName = "postman_api";
                });

            services.AddScoped<IAppUnitOfWork, AppUnitOfWork>();

            services.AddScoped<IManagersService, ManagersService>();
            services.AddScoped<IVenuesService, VenuesService>();

            services.AddMapper();
            services.AddValidation();
            services.AddSeeding<AppDbContext>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseAuthentication();

            app.UseSwaggerUi3WithApiExplorer();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "getMenuCategories",
                    template: "api/venues/{venueId}/menucategories",
                    defaults: new { controller = "MenuCategories", action = "GetMenuCategories" });

                routes.Select().Expand().Filter().OrderBy().MaxTop(100).Count();
                routes.MapODataServiceRoute("ODataRoutes", "api", TapsterEdmModel.GetModel());

                routes.EnableDependencyInjection();


            });
        }
    }
}
