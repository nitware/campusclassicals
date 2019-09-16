using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using CampusClassicals.Core.Infrastructure;
using CampusClassicals.Web.Infrastructure.Extensions;

namespace CampusClassicals.Web
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;

        public Startup(IHostingEnvironment env)
        {
            _env = env;

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

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add application services.
            services.AddTransient<ITypeFinder, AppTypeFinder>();
            services.RegisterCustomServices(Configuration["Data:ConnectionString"]);

            //RegisterServices(services, Configuration["Data:ConnectionString"]);






            //services.ConfigureApplicationCookie(opts => opts.LoginPath = "/Users/Login");


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

            //services.AddResponseCompression();
            //services.Configure<GzipCompressionProviderOptions>(options => {
            //    options.Level = System.IO.Compression.CompressionLevel.Fastest;
            //});




            //services.Configure<Microsoft.AspNetCore.Routing.RouteOptions>(opt => 
            //{
            //    opt.LowercaseUrls = true;
            //});



            if (!_env.IsDevelopment())
            {
                services.Configure<Microsoft.AspNetCore.Mvc.MvcOptions>(options =>
                {
                    options.Filters.Add(new Microsoft.AspNetCore.Mvc.RequireHttpsAttribute());
                });
            }

            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);
            services.AddMvc();
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
            app.UseStaticFiles();
            app.UseIdentity();

            

            //var options = new RewriteOptions().AddRedirectToHttpsPermanent();
            //app.UseRewriter(options);

            app.UseMvc(routes =>
            {
                //routes.MapRoute(
                //    name: "ShopSchema2",
                //    template: "Shop/Me",
                //    defaults: new { controller = "Home", action = "About" });
                
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller}/{action}/{id?}",
                    defaults: new { controller = "Dashboard", action = "Index" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
            });

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //       name: "default",
            //       template: "{controller=Home}/{action=Index}/{id?}");

            //    routes.MapRoute(
            //       name: "areaRoute",
            //       template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            //});
        }
        
        //public void RegisterServices(IServiceCollection services, string connectionString = null)
        //{
        //    // get type finder
        //    IServiceProvider serviceProvider = services.BuildServiceProvider();
        //    ITypeFinder typeFinder = serviceProvider.GetService<ITypeFinder>();
            
        //    //get registrars
        //    List<TypeInfo> registrars = typeFinder.FindClassesOfType<IDependencyRegistrar>();

        //    // create registrar instance list
        //    List<IDependencyRegistrar> registrarList = new List<IDependencyRegistrar>();
        //    registrars.ForEach(dr => registrarList.Add(Activator.CreateInstance(dr.AsType()) as IDependencyRegistrar));

        //    //sort
        //    registrarList = registrarList.OrderBy(x => x.Order).ToList();

        //    //register dependencies
        //    registrarList.ForEach(dr => dr.Register(services, connectionString));

        //    //IContainer container = containerBuilder.Build();
        //    //Initialize(config, container);
        //}

        

        

        






    }

    


}
