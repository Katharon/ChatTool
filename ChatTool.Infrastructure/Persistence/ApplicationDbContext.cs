// <copyright file="ApplicationDbContext.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace ChatTool.Infrastructure.Persistence
{
    using System;
    using ChatTool.Domain;
    using ChatTool.Infrastructure.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The application's database context that integrates ASP.NET Core Identity using GUID keys for users and roles.
    /// </summary>
    internal sealed class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class with the given options.
        /// </summary>
        /// <param name="options">The database context options.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
