using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FangZhouShuMa.Infrastructure.Identity;
using FangZhouShuMa.Infrastructure.Data;
using FangZhouShuMa.ApplicationCore.Interfaces;
using FangZhouShuMa.Infrastructure.Data.Repository;
using FangZhouShuMa.Infrastructure.Services;
using FangZhouShuMa.Infrastructure.Logging;
using FangZhouShuMa.ApplicationCore.Settings;
using FangZhouShuMa.Web.Services;
using FangZhouShuMa.Web.Interfaces;
using FangZhouShuMa.ApplicationCore.Services;
using FangZhouShuMa.Infrastructure.Interfaces.Product;
using FangZhouShuMa.Infrastructure.Data.Reports.Product;
using FangZhouShuMa.Web.Interfaces.ApiInterfaces;
using FangZhouShuMa.ApplicationCore.Interfaces.Repository;
using FangZhouShuMa.Web.Services.ApiServices;
using FangZhouShuMa.ApplicationCore.Interfaces.Services;

namespace FangZhouShuMa.Web
{
    public class Startup
    {
        private IServiceCollection _services;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")
                , b => b.MigrationsAssembly("FangZhouShuMa.Infrastructure")));

            services.AddDbContext<FangZhouShuMaContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")
                  , b => b.MigrationsAssembly("FangZhouShuMa.Infrastructure")));


            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));

            services.AddScoped<ProductRepository>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IBasketViewModelService, BasketViewModelService>();
            services.AddScoped<IQuoteService, QuoteService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IHomeService, HomeService>();
            services.Configure<ProductSettings>(Configuration);
          //  services.AddSingleton<IUriComposer>(new UriComposer(Configuration.Get<ProductSettings>()));
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            /*Need comment when you need to change to a new database*/
            //CreateUserRoles(serviceProvider).Wait();
        }

        private async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            IdentityResult roleResult;
            //Adding Admin Role
            var roleCheck = await RoleManager.RoleExistsAsync("Admin");
            if (!roleCheck)
            {
                //create the roles and seed them to the database
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin"));
            }

            roleCheck = await RoleManager.RoleExistsAsync("Manager");
            // creating Creating Manager role    
            if (!roleCheck)
            {
                //create the roles and seed them to the database
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Manager"));
            }

            roleCheck = await RoleManager.RoleExistsAsync("Employee");
            // creating Creating Employee role    
            if (!roleCheck)
            {
                //create the roles and seed them to the database
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Employee"));
            }

            roleCheck = await RoleManager.RoleExistsAsync("Customer");
            // creating Creating Customer role    
            if (!roleCheck)
            {
                //create the roles and seed them to the database
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Customer"));
            }

            //Assign Admin role to the main User here we have given our newly registered 
            //login id for Admin management
            //ApplicationUser user = await UserManager.FindByEmailAsync("David@orderbot.com");
            //var User = new ApplicationUser();
            //await UserManager.AddToRoleAsync(user, "Admin");
        }
    }
}
