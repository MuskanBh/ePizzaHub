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
            services.AddScoped<IRepository<Cart>, Repository<Cart>>();
            services.AddScoped<IRepository<CartItem>, Repository<CartItem>>();


            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICartRepository, CartRepository>();


            //services
            services.AddScoped<IService<User>, Service<User>>();
            services.AddScoped<IService<Item>, Service<Item>>();
            services.AddScoped<IService<Cart>, Service<Cart>>();
            services.AddScoped<IService<CartItem>, Service<CartItem>>();


            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<ICartService, CartService>();


        }
    }
}
