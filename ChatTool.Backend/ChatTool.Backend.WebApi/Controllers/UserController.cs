namespace ChatTool.Backend.WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ChatTool.Backend.Application.Users.DTOs;
    using ChatTool.Backend.Application.Users.Interfaces;
    using ChatTool.Backend.Persistence.Entities;
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet("GetAllUsers")]
        public IEnumerable<UserDto> GetAllUsers()
        {
            IEnumerable<ApplicationUser> dbUsers = userManager.Users.ToList();
            List<UserDto> users = new ();

            foreach (ApplicationUser dbUser in dbUsers)
            {
                users.Add(new UserDto
                {
                    UserName = dbUser.UserName ?? throw new NullReferenceException(),
                    Id = dbUser.Id,
                });

            }

            return users;
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
