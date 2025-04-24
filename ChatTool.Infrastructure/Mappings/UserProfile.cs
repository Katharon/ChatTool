// <copyright file="UserProfile.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace ChatTool.Infrastructure.Mappings
{
    using System;
    using AutoMapper;
    using ChatTool.Application.DTOs;
    using ChatTool.Infrastructure.Identity;

    /// <summary>
    /// .
    /// </summary>
    public class UserProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserProfile"/> class.
        /// </summary>
        public UserProfile()
        {
            this.CreateMap<ApplicationUser, UserDto>();
        }
    }
}
