// <copyright file="UserRepository.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace ChatTool.Infrastructure.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using ChatTool.Application.Commands;
    using ChatTool.Application.Common;
    using ChatTool.Application.DTOs;
    using ChatTool.Application.Interfaces;
    using ChatTool.Application.Queries;
    using ChatTool.Application.Results;
    using ChatTool.Infrastructure.Identity;
    using ChatTool.Infrastructure.Persistence;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// .
    /// </summary>
    internal class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="dbContext">.</param>
        public UserRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<UserDto>> ListAllUsersAsync(UserQueryParameters parameters, CancellationToken cancellationToken = default)
        {
            var users = await this.dbContext.Users
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return users.Select(u => new UserDto(displayName: u.Displayname));
        }

        /// <inheritdoc/>
        public async Task<UserDto?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var user = await this.dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id.ToString(), cancellationToken);

            return user is null ? null : new UserDto(user.Displayname);
        }

        /// <inheritdoc/>
        public async Task<IResult<UserDto>> CreateUserAsync(CreateUserCommand command, CancellationToken cancellationToken = default)
        {
            var user = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                Displayname = command.Displayname,
                Email = command.Email,
                UserName = command.Email,
            };

            await this.dbContext.Users.AddAsync(user, cancellationToken);
            await this.dbContext.SaveChangesAsync(cancellationToken);

            return Result.Success(new UserDto(user.Displayname));
        }

        /// <inheritdoc/>
        public async Task<IResult<UserDto>> UpdateUserAsync(UpdateUserCommand command, CancellationToken cancellationToken = default)
        {
            var user = await this.dbContext.Users.FindAsync(new object[] { command.Id.ToString() }, cancellationToken);
            if (user is null)
            {
                return Result.Failure<UserDto>("Benutzer nicht gefunden.");
            }

            user.Displayname = command.Displayname;
            user.Email = command.Email;
            user.UserName = command.Email;

            this.dbContext.Users.Update(user);
            await this.dbContext.SaveChangesAsync(cancellationToken);

            return Result.Success(new UserDto(user.Displayname));
        }

        /// <inheritdoc/>
        public async Task<IResult<Empty>> DeleteUserAsync(DeleteUserCommand command, CancellationToken cancellationToken = default)
        {
            var user = await this.dbContext.Users.FindAsync(new object[] { command.Id.ToString() }, cancellationToken);
            if (user is null)
            {
                return Result.Failure<Empty>("Benutzer nicht gefunden.");
            }

            this.dbContext.Users.Remove(user);
            await this.dbContext.SaveChangesAsync(cancellationToken);

            return Result.Success(Empty.Value);
        }
    }
}
