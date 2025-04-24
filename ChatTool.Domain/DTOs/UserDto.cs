// <copyright file="UserDto.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace ChatTool.Domain.DTOs
{
    /// <summary>
    /// .
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserDto"/> class.
        /// </summary>
        /// <param name="displayName">.</param>
        public UserDto(string displayName)
        {
            this.Displayname = displayName;
        }

        /// <summary>
        /// Gets or sets.
        /// </summary>
        public string Displayname { get; set; }
    }
}