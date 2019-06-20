using AudioNetwork1.Configurations;
using AudioNetwork1.Helpers;
using AudioNetwork1.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

 /*
     Please use C# to produce a simple solution for the following user story:

    ==As a user I want to see a list of tracks in the rock genre==
    ++Acceptance criteria:++
    * Can see a list of track names in alphabetical order
    * Can see the composer of each track

    We have created this API to save you some time:

    Demo API: https://private-dcdc80-audionetworkrecruitment.apiary-mock.com
    API Documentation : https://audionetworkrecruitment.docs.apiary.io
 * 
 */


namespace AudioNetwork1
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
            ConfigureSettings(services);

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            ConfigureDependencies(services);

        }

        private void ConfigureDependencies(IServiceCollection services)
        {
            services.AddSingleton<IHttpClientAccessor, DefaultHttpClientAccessor>();
            //Add Track service
            services.AddScoped<ITrackService, TrackService>();
        }

        private void ConfigureSettings(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
