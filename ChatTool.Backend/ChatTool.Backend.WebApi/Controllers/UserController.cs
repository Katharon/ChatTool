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

        [HttpPost("getAll")]
        public IEnumerable<UserDto> GetAllContacts()
        {
            IQueryable<ApplicationUser> dbUsers = userManager.Users;
            List<UserDto> user = new List<UserDto>();

            foreach (ApplicationUser dbUser in dbUsers)
            {
                user.Add(new UserDto
                {
                    UserName = dbUser.UserName!,
                    Id = dbUser.Id,
                });
            }

            return user;
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
