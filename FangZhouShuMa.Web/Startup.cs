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
using FangZhouShuMa.DataAccess;
using FangZhouShuMa.DataAccess.Models;
using FangZhouShuMa.Web.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace FangZhouShuMa.Web
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")
                , b => b.MigrationsAssembly("FangZhouShuMa.DataAccess")));

            services.AddDbContext<FangZhouShuMaContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")
                  , b => b.MigrationsAssembly("FangZhouShuMa.DataAccess")));


            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
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

            CreateUserRoles(serviceProvider).Wait();
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
