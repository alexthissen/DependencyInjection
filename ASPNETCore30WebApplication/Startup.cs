using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Refit;
using Polly;
using Polly.Registry;
using ASPNETCore30WebApplication.Demos;
using ASPNETCore30WebApplication.Infrastructure;
using System.Reflection;

namespace ASPNETCore30WebApplication
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                var appAssembly = Assembly.Load(new AssemblyName(env.ApplicationName));
                if (appAssembly != null)
                {
                    builder.AddUserSecrets(appAssembly, optional: true);
                }
            }
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Custom registrations
            services.AddSingleton<IRing, TheOneRing>();
            services.AddTransient<IOnce, Matchstick>();
            //services.AddDemos();

            // Extension methods for registering service type descriptors
            services.AddHttpClient("ImpatientClient", options =>
                {
                    options.Timeout = TimeSpan.FromMilliseconds(500);
                })
                .AddPolicyHandlerFromRegistry("Impatient")
                .AddTransientHttpErrorPolicy(p => p.RetryAsync(3))
                .AddTypedClient(client => RestService.For<IGenderizeClient>(client));
            services.AddHealthChecks();

            // Configuration options
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.Configure<GenderizeApiOptions>(Configuration.GetSection("GenderizeApiOptions"));
            services.AddOptions<GenderizeApiOptions>()
                .Configure<IRing, IOnce>((options, ring, once) =>
                    {
                        options.Cache = ring.CanIRuleThemAll();
                    })
                .Validate(options => String.IsNullOrEmpty(options.DeveloperApiKey));

            services.AddMvc()
                .AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting(routes =>
            {
                routes.MapControllerRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRazorPages();
            });

            app.UseCookiePolicy();

            app.UseAuthorization();
        }
    }
}
