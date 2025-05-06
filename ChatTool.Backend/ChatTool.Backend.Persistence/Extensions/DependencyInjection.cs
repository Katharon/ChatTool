namespace ChatTool.Backend.Persistence.Extensions
{
    using ChatTool.Backend.Application.Messages.Interfaces;
    using ChatTool.Backend.Persistence.Context;
    using ChatTool.Backend.Persistence.Entities;
    using ChatTool.Backend.Persistence.Repositories;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MessengerDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<MessengerDbContext>()
            .AddDefaultTokenProviders();

            // services.AddScoped<IMessageRepository, MessageRepository>();

            return services;
        }
    }
}
