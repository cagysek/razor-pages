using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using AccountingApp.Services;
using Microsoft.AspNetCore.Http;
using AccountingApp.App_Code;

namespace AccountingApp
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
            services.AddSession(options =>
            {
                options.Cookie.Name = ".AdventureWorks.Session";
                options.IdleTimeout = TimeSpan.FromSeconds(3600);
                options.Cookie.IsEssential = true;
            });

            services.AddAutoMapper(typeof(AutoMapperClass));

            services.AddRazorPages();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DatabaseContext")));


            services.AddMvc().AddRazorOptions(options =>
            {
                options.PageViewLocationFormats
                 .Add("/Pages/Shared/PartialView/{0}.cshtml");
            });

            services.AddTransient<ISessionService, SessionService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

           
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
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseStatusCodePages();

            app.UseSession();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
