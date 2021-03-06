﻿using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Storyboard.Web.Models;
using Storyboard.Domain.Services;
using Storyboard.Domain.Data;
using Storyboard.Data.Core;
using HDLink;
using Storyboard.Data;
using Storyboard.Domain.Core;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNet.FileProviders;
using Microsoft.AspNet.StaticFiles;

namespace Storyboard.Web
{
    public class Startup
    {
        private IHostingEnvironment env;
        private IApplicationEnvironment appEnv;
        public IConfigurationRoot Configuration { get; set; }

        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
        {
            this.env = env;
            this.appEnv = appEnv;
            var builder = new ConfigurationBuilder()
                .SetBasePath(appEnv.ApplicationBasePath)
                .AddJsonFile("config.json")
                .AddJsonFile($"config.{env.EnvironmentName}.json", optional: true);

            //.AddJsonFile($"config.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This reads the configuration keys from the secret store.
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();
            }
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add Application settings to the services container.
            //services.Configure<AppSettings>(Configuration.GetSubKey("AppSettings"));

            // Add EF services to the services container.
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]))
                .AddDbContext<StoryboardContext>(options =>
                    options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));

            // Add Identity services to the services container.
            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();
            
            services.AddTransient<IAsyncNodeService, AsyncNodeService>();
            services.AddTransient<IActorRepository, ActorRepository>();
            services.AddTransient<IStorySectionRepository, StorySectionRepository>();
            services.AddTransient<IStoryReadService, StoryReadService>();
            services.AddTransient<IStoryRepository, StoryRepository>();
            services.AddTransient<IAsyncLinkRepository, LinkRepository>();
            services.AddTransient<IAsyncNodeRepositoryFactory, StoryboardNodeRepositoryFactory>();
            services.AddTransient<ILinkDataService, LinkDataService>();
            services.AddTransient<IAsyncNodeRepository<Actor>, ActorRepository>();
            services.AddTransient<IAsyncNodeRepository<Story>, StoryRepository>();
            



            // Configure the options for the authentication middleware.
            // You can add options for Google, Twitter and other middleware as shown below.
            // For more information see http://go.microsoft.com/fwlink/?LinkID=532715
            //services.Configure<FacebookAuthenticationOptions>(options =>
            //{
            //    options.AppId = Configuration["Authentication:Facebook:AppId"];
            //    options.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            //});

            //services.Configure<MicrosoftAccountAuthenticationOptions>(options =>
            //{
            //    options.ClientId = Configuration["Authentication:MicrosoftAccount:ClientId"];
            //    options.ClientSecret = Configuration["Authentication:MicrosoftAccount:ClientSecret"];
            //});

            // Add MVC services to the services container.
            services.AddMvc();




            // Uncomment the following line to add Web API services which makes it easier to port Web API 2 controllers.
            // You will also need to add the Microsoft.AspNet.Mvc.WebApiCompatShim package to the 'dependencies' section of project.json.
            //services.AddWebApiConventions();
        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerfactory)
        {
            // Configure the HTTP request pipeline.
            
            // Add the console logger.
            loggerfactory.AddConsole(minLevel: LogLevel.Warning);

            // Add the following to the request pipeline only in development environment.
            if (env.IsEnvironment("Development"))
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                // Add Error handling middleware which catches all application specific errors and
                // sends the request to the following path or controller action.
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseIISPlatformHandler();
            // Add static files to the request pipeline.
            app.UseFileServer();

            // this will serve up node_modules
            var provider = new PhysicalFileProvider(
                env.MapPath("../node_modules")
                //Path.Combine(env. ApplicationBasePath, "node_modules")
            );
            var options = new FileServerOptions();
            options.RequestPath = "/node_modules";
            options.StaticFileOptions.FileProvider = provider;
            options.EnableDirectoryBrowsing = true;
            app.UseFileServer(options);


            // Add cookie-based authentication to the request pipeline.
            app.UseIdentity();

            // Add authentication middleware to the request pipeline. You can configure options such as Id and Secret in the ConfigureServices method.
            // For more information see http://go.microsoft.com/fwlink/?LinkID=532715
            // app.UseFacebookAuthentication();
            // app.UseGoogleAuthentication();
            // app.UseMicrosoftAccountAuthentication();
            // app.UseTwitterAuthentication();
            
            // Add MVC to the request pipeline.
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });

               // Uncomment the following line to add a route for porting Web API 2 controllers.
               routes.MapWebApiRoute("DefaultApi", "api/{controller}/{id?}");
            });
            
        }
    }
}
