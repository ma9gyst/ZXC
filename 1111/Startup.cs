using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1111.Hubs;
using _1111.MapperProfile;
using Domain.Core.Entities;
using Domain.Interfaces.Base;
using Infrastructure.Data.Entity_Framework;
using Infrastructure.Data.Entity_Framework.Repository;
using Infrastructure.Data.Entity_Framework.Repository.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.Data;
using Services.Interfaces;

namespace _1111
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
            services.AddControllersWithViews();

            // �������� ������ ����������� �� ����� ������������
            string connection = Configuration.GetConnectionString("DefaultConnection");


            services.AddScoped(typeof(IRepositoryAsync<Hero>), typeof(HeroRepositoryAsync));

            services.AddScoped(typeof(IRepositoryAsync<AppUser>), typeof(UserRepositoryAsync));

            services.AddTransient<IUserService, UserService>();

            services.AddTransient<IHeroService, HeroService>();

            // ��������� �������� MobileContext � �������� ������� � ����������
            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(connection));

            services.AddIdentity<AppUser, ApplicationRole>(
    options =>
        options.Password = new PasswordOptions
        {
            RequireDigit = true,
            RequiredLength = 6,
            RequireLowercase = true,
            RequireUppercase = true
        })
                .AddEntityFrameworkStores<DatabaseContext>()
                //.AddEntityFrameworkStores<DatabaseContext, Guid>()
                .AddDefaultTokenProviders();

            services.AddScoped(typeof(IRepositoryAsync<Hero>), typeof(HeroRepositoryAsync));
            services.AddScoped(typeof(IRepositoryAsync<Matchup>), typeof(MatchupRepositoryAsync));
            services.AddTransient<IHeroService, HeroService>();
            services.AddTransient<IMatchupService, MatchupService>();
            services.AddTransient<IAutoMapper, _1111.MapperProfile.AutoMapper>();
            services.AddSignalR();
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHub<ChatHub>("/chathub");
            });
        }
    }
}
