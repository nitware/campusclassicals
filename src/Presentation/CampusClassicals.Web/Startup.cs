using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using System.Reflection;
using CampusClassicals.Core.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CampusClassicals.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            //IdentityUser u;
            //IdentityRole r;
            //UserManager<IdentityUser> um;
            
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add application services.
            services.AddTransient<ITypeFinder, AppTypeFinder>();
            RegisterServices(services, Configuration["Data:ConnectionString"]);

            //IHostedService
            //IWebHost
            //services.AddEntityFrameworkSqlServer();
            //IdentityDbContext

            //services.AddIdentity<IdentityUser, IdentityRole>(o =>
            //{
            //    o.Password.RequireUppercase = true;
            //    o.Password.RequireNonAlphanumeric = true;
            //}).AddEntityFrameworkStores<>()
            //.AddDefaultTokenProviders();

            //services.AddAuthentication().AddGoogle();

            //Microsoft.AspNetCore.Identity.SignInManager<IdentityUser> sm;
            //sm.SignInAsync()

            //Microsoft.AspNetCore.Authorization.IAuthorizationHandler

            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);
            services.AddMvc();

            //services.AddResponseCompression();
            //services.Configure<GzipCompressionProviderOptions>(options => {
            //    options.Level = System.IO.Compression.CompressionLevel.Fastest;
            //});


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            
            app.UseApplicationInsightsExceptionTelemetry();
            //app.UseIdentity();
            app.UseStaticFiles();
            //app.UseCookieAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        public void RegisterServices(IServiceCollection services, string connectionString = null)
        {
            // get type finder
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            ITypeFinder typeFinder = serviceProvider.GetService<ITypeFinder>();
            
            //get registrars
            List<TypeInfo> registrars = typeFinder.FindClassesOfType<IDependencyRegistrar>();

            // create registrar instance list
            List<IDependencyRegistrar> registrarList = new List<IDependencyRegistrar>();
            registrars.ForEach(dr => registrarList.Add(Activator.CreateInstance(dr.AsType()) as IDependencyRegistrar));

            //sort
            registrarList = registrarList.OrderBy(x => x.Order).ToList();

            //register dependencies
            registrarList.ForEach(dr => dr.Register(services, connectionString));

            //IContainer container = containerBuilder.Build();
            //Initialize(config, container);
        }

        

        

        






    }
}
