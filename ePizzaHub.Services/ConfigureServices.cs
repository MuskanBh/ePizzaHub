using ePizzaHub.Core;
using ePizzaHub.Core.Entities;
using ePizzaHub.Repositories.Implementations;
using ePizzaHub.Repositories.Interfaces;
using ePizzaHub.Services.Implementations;
using ePizzaHub.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ePizzaHub.Services
{
    public static class ConfigureServices
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DbConnection"));
            });
            services.AddScoped<DbContext, AppDbContext>();


            //repositories
            services.AddScoped<IRepository<User>, Repository<User>>();
            services.AddScoped<IRepository<Item>, Repository<Item>>();


            services.AddScoped<IUserRepository, UserRepository>();

            //services
            services.AddScoped<IService<User>, Service<User>>();
            services.AddScoped<IService<Item>, Service<Item>>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<IItemService, ItemService>();

        }
    }
}
