// <copyright file="ApplicationUser.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace ChatTool.Infrastructure.Identity
{
    using Microsoft.AspNetCore.Identity;

    /// <summary>
    /// Represents a custom user entity for the ChatTool application, using a GUID as the primary key.
    /// </summary>
    internal sealed class ApplicationUser : IdentityUser<Guid>
    {
    }
}