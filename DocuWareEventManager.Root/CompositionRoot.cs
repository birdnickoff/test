using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using DocuWareEventManager.DAL;
using Microsoft.EntityFrameworkCore;
using DocuWareEventManager.BLL.Services;
using DocuWareEventManager.BLL.Services.Impl;
using DocuWareEventManager.DAL.Repositories;
using DocuWareEventManager.DAL.Repositories.Impl;

namespace DocuWareEventManager.Root
{
    public static class CompositionRoot
    {
        public static void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            // register dependencies here

            services.AddDbContext<DocuWareEventManagerContext>(options =>
                options.EnableSensitiveDataLogging().UseSqlServer(configuration.GetConnectionString("DocuWareEventsDatabase")));
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IEventService, EventService>();
            services.AddTransient<IEventRepository, EventRepository>();
        }
    }

}
