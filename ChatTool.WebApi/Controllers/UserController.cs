// <copyright file="UserController.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace ChatTool.WebApi.Controllers
{
    using ChatTool.Application.Common;
    using ChatTool.Application.DTOs;
    using ChatTool.Application.Interfaces;
    using ChatTool.Application.Results;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// .
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userService">.</param>
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// .
        /// </summary>
        /// <returns>..</returns>
        [HttpGet]
        public Task<IEnumerable<UserDto>> GetAll()
        {
            return this.userService.ListAllUsersAsync(null!);
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="id">..</param>
        /// <returns>...</returns>
        [HttpGet("{id}")]
        public Task<UserDto?> Get(Guid id)
        {
            return this.userService.GetUserByIdAsync(id);
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="value">..</param>
        /// <returns>...</returns>
        [HttpPost]
        public Task<IResult<UserDto>> Post([FromBody] string value)
        {
            return this.userService.CreateUserAsync(CreateUserCommand.Create());
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="id">..</param>
        /// <param name="value">...</param>
        /// <returns>....</returns>
        [HttpPut("{id}")]
        public Task<IResult<UserDto>> Put(int id, [FromBody] string value)
        {
            return this.userService.GetUserByIdAsync(null!);
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="user">..</param>
        /// <returns>...</returns>
        [HttpDelete("{user}")]
        public Task<IResult<Empty>> Delete(UserDto user)
        {
            return this.userService.GetUserByIdAsync(null!);
        }
    }
}
