// <copyright file="IUserService.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace ChatTool.Application.Interfaces
{
    using System;
    using System.Collections.Generic;
    using ChatTool.Application.Commands;
    using ChatTool.Application.Common;
    using ChatTool.Application.DTOs;
    using ChatTool.Application.Queries;
    using ChatTool.Application.Results;

    /// <summary>
    /// .
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// .
        /// </summary>
        /// <param name="parameters">..</param>
        /// <param name="cancellationToken">...</param>
        /// <returns>....</returns>
        Task<IEnumerable<UserDto>> ListAllUsersAsync(UserQueryParameters parameters, CancellationToken cancellationToken = default);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="id">..</param>
        /// <param name="cancellationToken">...</param>
        /// <returns>....</returns>
        Task<UserDto?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="command">..</param>
        /// <param name="cancellationToken">...</param>
        /// <returns>....</returns>
        Task<IResult<UserDto>> CreateUserAsync(CreateUserCommand command, CancellationToken cancellationToken = default);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="command">..</param>
        /// <param name="cancellationToken">...</param>
        /// <returns>....</returns>
        Task<IResult<UserDto>> UpdateUserAsync(UpdateUserCommand command, CancellationToken cancellationToken = default);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="command">..</param>
        /// <param name="cancellationToken">...</param>
        /// <returns>....</returns>
        Task<IResult<Empty>> DeleteUserAsync(DeleteUserCommand command, CancellationToken cancellationToken = default);
    }
}