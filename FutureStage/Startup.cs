using FutureStage.Data;
using FutureStage.Data.Services.SchoolsServices;
using FutureStage.Data.Services.SiteAdminServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //DbContext configuration
            services.AddDbContextPool<AppDbContext>(options => options.UseLazyLoadingProxies().UseSqlServer(this.Configuration.GetConnectionString("DefaultConnectionString")));

            //Services configuration
                //SiteAdmin services
            services.AddScoped<IStateService, StateService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IAreaService, AreaService>();
            services.AddScoped<IMediumService, MediumService>();
            services.AddScoped<IFacilityService, FacilityService>();
            services.AddScoped<IStandardService, StandardService>();
            services.AddScoped<IEducationBoardService, EducationBoardService>();
            services.AddScoped<IQuotaService, QuotaService>();
            //Schools services
            services.AddScoped<ISchoolService, SchoolService>();
            services.AddScoped<IFeeHeadService, FeeHeadService>();
            services.AddScoped<ISchoolStandardService, SchoolStandardService>();
            services.AddScoped<ISchoolFacilityService, SchoolFacilityService>();

            services.AddControllersWithViews();

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.Cookie.IsEssential = true;
                options.Cookie.HttpOnly = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSession();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "arearoute",
                    pattern: "{area:exists}/{controller=Home}/{action=index}/{id?}"
                    );
                endpoints.MapDefaultControllerRoute();
            });

            //Seed Database
            AppDbInitializer.Seed(app);
        }
    }
}
