// <copyright file="DependencyWrapper.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace ChatTool.Dependencies
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using static ChatTool.Application.Common.DependencyInjection;
    using static ChatTool.Infrastructure.Common.DependencyInjection;

    /// <summary>
    /// .
    /// </summary>
    public static class DependencyWrapper
    {
        /// <summary>
        /// .
        /// </summary>
        /// <param name="services">..</param>
        /// <param name="configuration">...</param>
        /// <returns>....</returns>
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services = AddApplication(services);
            services = AddInfrastructure(services, configuration);
            return services;
        }
    }
}
