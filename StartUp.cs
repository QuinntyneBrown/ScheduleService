using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ScheduleService.Data;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace ScheduleService
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup));
            services.AddMvc();
            services.AddDbContext<ScheduleServiceContext>((options) => {
                options.UseSqlServer(@"Server=.\SQLEXPRESS;Database=ScheduleService;Integrated Security=True;Connect Timeout=30;MultipleActiveResultSets=True;");
            });
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {           
            app.UseMvc();
        }
    }
}