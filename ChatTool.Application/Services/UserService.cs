// <copyright file="UserService.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace ChatTool.Application.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using ChatTool.Application.Commands;
    using ChatTool.Application.Common;
    using ChatTool.Application.DTOs;
    using ChatTool.Application.Interfaces;
    using ChatTool.Application.Queries;
    using ChatTool.Application.Results;

    /// <summary>
    /// .
    /// </summary>
    internal class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="userRepository">.</param>
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public Task<IResult<UserDto>> CreateUserAsync(CreateUserCommand command, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IResult<Empty>> DeleteUserAsync(DeleteUserCommand command, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDto>> ListAllUsersAsync(UserQueryParameters parameters, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IResult<UserDto>> UpdateUserAsync(UpdateUserCommand command, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
