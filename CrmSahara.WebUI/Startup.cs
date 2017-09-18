using CrmSahara.Domain.Repositories;
using CrmSahara.Infrastructure.Mappers;
using CrmSahara.Infrastructure.Repositories;
using CrmSahara.Infrastructure.Services.Abstract;
using CrmSahara.Infrastructure.Services.Implementation;
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
			services.AddSingleton(AutoMapperConfig.Initialize());

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IPriorityRepository, PriorityRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();

	        services.AddScoped<IUserService, UserService>();
	        services.AddScoped<ITaskService, TaskService>();
	        services.AddScoped<IPriorityService, PriorityService>();
	        services.AddScoped<IStatusService, StatusService>();
	        services.AddScoped<ICommentService, CommentService>();

           

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
