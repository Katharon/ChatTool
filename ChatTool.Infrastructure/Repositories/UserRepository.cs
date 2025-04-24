// <copyright file="UserRepository.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace ChatTool.Infrastructure.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ChatTool.Application.Interfaces;
    using ChatTool.Domain;
    using ChatTool.Domain.DTOs;

    /// <summary>
    /// .
    /// </summary>
    internal class UserRepository : IUserRepository
    {
        /// <inheritdoc/>
        public IEnumerable<UserDto> GetAll()
        {
            return new List<UserDto> { new UserDto("Lukas") };
        }

        /// <inheritdoc/>
        public UserDto Get(int id)
        {
            return new UserDto("Lukas");
        }

        /// <inheritdoc/>
        public UserDto Create(UserDto user)
        {
        }

        /// <inheritdoc/>
        public UserDto Update(UserDto oldUser, UserDto updatedUser)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public bool Delete(UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
