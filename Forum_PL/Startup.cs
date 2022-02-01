using AutoMapper;
using Forum_BLL.Infrastructure;
using Forum_BLL.Interfaces;
using Forum_BLL.Services;
using Forum_DAL.Context;
using Forum_DAL.Entities;
using Forum_DAL.Interfaces;
using Forum_DAL.Repositories;
using Forum_DAL.UnitOfWork;
using Forum_PL.Filters;
using Forum_PL.Helpers;
using Forum_PL.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum_PL
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
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<ISectionRepository, SectionRepository>();
            services.AddScoped<ITopicRepository, TopicRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<ITopicService, TopicService>();
            services.AddScoped<ISectionService, SectionService>();
            services.AddScoped<IUserService, UserService>();
            services.AddDbContext<ForumDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ForumDB")));

            services.Configure<JwtSettings>(Configuration.GetSection("Jwt"));


            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new EntityDTOProfile());
                mc.AddProfile(new DtoModelsProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddIdentity<User, IdentityRole>(options=>
            {
                options.Password.RequiredLength = 5;

            }).AddEntityFrameworkStores<ForumDbContext>();
            services.AddControllers(options =>
            {
                options.Filters.Add(new CustomExceptionFilterAttribute()); 
            });
            services.AddRazorPages();
            
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
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoins =>
            {
                endpoins.MapRazorPages();
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
      

        }
    }
}
