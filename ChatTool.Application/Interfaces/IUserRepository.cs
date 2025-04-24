// <copyright file="IUserRepository.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace ChatTool.Application.Interfaces
{
    using System.Collections.Generic;
    using ChatTool.Domain;
    using ChatTool.Domain.DTOs;

    /// <summary>
    /// .
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// .
        /// </summary>
        /// <returns>..</returns>
        IEnumerable<UserDto> GetAll();

        /// <summary>
        /// .
        /// </summary>
        /// <param name="id">..</param>
        /// <returns>...</returns>
        UserDto Get(int id);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="user">..</param>
        /// <returns>...</returns>
        UserDto Create(UserDto user);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="oldUser">..</param>
        /// <param name="updatedUser">...</param>
        /// <returns>....</returns>
        UserDto Update(UserDto oldUser, UserDto updatedUser);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="user">..</param>
        /// <returns>...</returns>
        bool Delete(UserDto user);
    }
}
