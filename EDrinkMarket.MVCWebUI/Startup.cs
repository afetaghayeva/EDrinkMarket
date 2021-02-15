using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using EDrinkMarket.Business.Abstract;
using EDrinkMarket.Business.Concrete;
using EDrinkMarket.Business.ValidationRules.FluentValidation;
using EDrinkMarket.DataAccess.Abstract;
using EDrinkMarket.DataAccess.Concrete.EntityFramework;
using EDrinkMarket.DataAccess.Concrete.EntityFramework.Contexts;
using EDrinkMarket.Entity.Concrete;
using EDrinkMarket.MVCWebUI.Helpers.Abstract;
using EDrinkMarket.MVCWebUI.Helpers.Concrete;
using EDrinkMarket.MVCWebUI.Migrations;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace EDrinkMarket.MVCWebUI
{
    public class Startup
    {
        private readonly IConfigurationRoot _configurationRoot;

        public Startup(IWebHostEnvironment environment)
        {
            _configurationRoot = new ConfigurationBuilder().SetBasePath(environment.ContentRootPath).AddJsonFile
                ("appsettings.json").Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EDrinkMarketContext>(options=>options.UseSqlServer(_configurationRoot.GetConnectionString
                ("DefaultConnection"),b=>b.MigrationsAssembly("EDrinkMarket.MVCWebUI")));

            services.AddScoped<IDrinkDal, EfDrinkDal>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddScoped<IDrinkService, DrinkManager>();
            services.AddScoped<ICategoryService,CategoryManager>();
            services.AddScoped<ICartService, CartManager>();
            services.AddScoped<ICartSessionHelper, CartSessionHelper>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IValidator<Order>, OrderValidator>();
            services.AddScoped<IOrderDal, EfOrderDal>();
            services.AddScoped<IOrderDetailDal, EfOrderDetailDal>();
            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<IOrderDetailsService, OrderDetailManager>();
            services.AddControllersWithViews().AddFluentValidation();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IServiceProvider serviceProvider)
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            DbInitializer.Seed(serviceProvider);
        }
    }
}
