// <copyright file="ApplicationRole.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace ChatTool.Infrastructure.Identity
{
    using Microsoft.AspNetCore.Identity;

    /// <summary>
    /// Represents a custom role entity for the ChatTool application, using a GUID as the primary key.
    /// </summary>
    internal sealed class ApplicationRole : IdentityRole<Guid>
    {
    }
}