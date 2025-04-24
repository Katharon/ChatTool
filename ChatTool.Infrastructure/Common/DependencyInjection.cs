// <copyright file="DependencyInjection.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace ChatTool.Infrastructure.Common
{
    using ChatTool.Application.Interfaces;
    using ChatTool.Infrastructure.Identity;
    using ChatTool.Infrastructure.Persistence;
    using ChatTool.Infrastructure.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Provides dependency injection extensions for the Infrastructure layer.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Adds all infrastructure-related services, including Entity Framework and ASP.NET Core Identity.
        /// </summary>
        /// <param name="services">The service collection to register the dependencies with.</param>
        /// <param name="configuration">The application configuration instance.</param>
        /// <returns>The updated service collection.</returns>
        public static IServiceCollection AddInfrastructure(IServiceCollection services, IConfiguration configuration)
        {
            // EF Core + DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Identity (User, Roles)
            services.AddIdentityCore<ApplicationUser>(options =>
            {
                options.User.RequireUniqueEmail = true;
            })
            .AddRoles<ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

            // Services
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
