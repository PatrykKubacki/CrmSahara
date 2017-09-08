using CrmSahara.Domain.Repositories.Abstract;
using CrmSahara.Infrastructure.Mappers;
using CrmSahara.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrmSahara.WebUI
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
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IPriorityRepository, PriorityRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddSingleton(AutoMapperConfig.Initialize());
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes => 
            {
                routes.MapRoute(
                    name: null,
                    template: "{controller=Home}/{action=Index}/{id?}/{statusId?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
