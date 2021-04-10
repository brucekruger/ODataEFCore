using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using ODataEFCore.Interfaces;
using ODataEFCore.Models;
using ODataEFCore.OData;
using ODataEFCore.Repository;

namespace ODataEFCore
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
            services.AddDbContext<AdventureWorks2019Context>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ODataEFCore", Version = "v1" });
            });

            services.AddScoped<IAdventureWorksRepository, AdventureWorksRepository>();
            services.AddOData();
            services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ODataEFCore v1"));
            }

            var model = EdmModelBuilder.Build();

            app.UseOData(model);

            app.UseMvc(builder =>
            {
                builder.Select().Expand().Filter().OrderBy().MaxTop(1000).Count();
                builder.MapODataServiceRoute("odata", "odata", model);
                builder.MapRoute(
                    name: "Default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // set which functionalities are supported
                endpoints.Select().Expand().Filter().OrderBy().MaxTop(1000).Count();

                // map the OData Route
                endpoints.MapODataRoute("odata", "odata", model);

                // map the default controller route
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
