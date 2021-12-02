using DataAccessLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace BusBookingAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        //https://www.yogihosting.com/jwt-api-aspnet-core/#download
        //https://www.c-sharpcorner.com/article/how-to-use-jwt-authentication-with-web-api/
        //good: https://jasonwatmore.com/post/2020/05/25/aspnet-core-3-api-jwt-authentication-with-refresh-tokens#refresh-token-cs
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors();
            services.AddHttpContextAccessor();
            services.Configure<AppsettingModles>(Configuration.GetSection(CommonInformation.Appsettingkey));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IOptions<AppsettingModles> configP)
        {
            AppsettingModles Appsettig = configP.Value;
            Appsettig.CopytoStatic();
            string[] Apirul = { AppsettingModlesStatic.AppUrl, AppsettingModlesStatic.AppUrlMVC };

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseCors(options => options.WithOrigins(Apirul)
                                        .AllowAnyMethod()
                                        .AllowAnyHeader()
                                        .AllowCredentials());
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
