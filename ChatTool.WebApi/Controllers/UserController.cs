// <copyright file="UserController.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace ChatTool.WebApi.Controllers
{
    using ChatTool.Application.Interfaces;
    using ChatTool.Domain.DTOs;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// .
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userRepository">.</param>
        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        /// <summary>
        /// .
        /// </summary>
        /// <returns>..</returns>
        [HttpGet]
        public IEnumerable<UserDto> GetAll()
        {
            return this.userRepository.GetAll();
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="id">..</param>
        /// <returns>...</returns>
        [HttpGet("{id}")]
        public UserDto Get(int id)
        {
            return this.userRepository.Get(id);
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="value">..</param>
        /// <returns>...</returns>
        [HttpPost]
        public UserDto Post([FromBody] string value)
        {
            return this.userRepository.Create();
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="id">..</param>
        /// <param name="value">...</param>
        /// <returns>....</returns>
        [HttpPut("{id}")]
        public UserDto Put(int id, [FromBody] string value)
        {
            return this.userRepository.Update(new UserDto("Lukass"), new UserDto("Lukas"));
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="user">..</param>
        /// <returns>...</returns>
        [HttpDelete("{user}")]
        public bool Delete(UserDto user)
        {
            return this.userRepository.Delete(new UserDto("Lukas"));
        }
    }
}
