// <copyright file="DependencyInjection.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace ChatTool.Application.Common
{
    using ChatTool.Application.Interfaces;
    using ChatTool.Application.Services;
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
        /// <returns>The updated service collection.</returns>
        public static IServiceCollection AddApplication(IServiceCollection services)
        {
            // Services
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
