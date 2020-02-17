using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceLayer.OrderService.Abstract;
using ServiceLayer.OrderService.Concrete;
using ServiceLayer.ProductService.Abstract;
using ServiceLayer.ProductService.Concrete;

namespace WebShop
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
            services.AddScoped<IListProductService, ListProductService>();
            services.AddScoped<IProductFilterDropdownService, ProductFilterDropdownService>();
            services.AddScoped<IDeliveryPaymentDropdownService, DeliveryPaymentDropdownService>();
            services.AddScoped<IListOrderService, ListOrderService>();

            services.AddDbContext<EshopContext>(options => options.UseSqlServer(Configuration.GetConnectionString("WebShop")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<EshopContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();
            // services.AddDefaultIdentity<IdentityUser>() 
            services.AddRazorPages();
            services.AddMvc();
            #region MINI PROFILING
            services.AddMiniProfiler(options =>
            {
                options.TrackConnectionOpenClose = true;
            }).AddEntityFramework();
            #endregion

            #region SESSION
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true;
                // Make the session cookie essential
                options.Cookie.IsEssential = true;
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<ApplicationUser> userManager)
        {
           
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMiniProfiler();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            #region SESSION
            app.UseSession();
            #endregion

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
            SeedUsers(userManager);
        }

        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByEmailAsync("abc@xyz.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "hej@hej.dk",
                    FirstName = "hej@hej.dk",
                    LastName = "hej@hej.dk",
                    Email = "hej@hej.dk"
                };

                IdentityResult result = userManager.CreateAsync(user, "P@ssw0rd").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                    userManager.GenerateEmailConfirmationTokenAsync(user);
                }
            }
        }
    }
}
