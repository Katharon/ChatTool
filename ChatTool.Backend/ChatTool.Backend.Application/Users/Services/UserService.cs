namespace ChatTool.Backend.Application.Users.Services
{
    using ChatTool.Backend.Application.Users.DTOs;
    using System.Collections.Generic;
    using System.Net.Http.Json;
    using System.Threading.Tasks;

    public class UserService
    {
        private readonly HttpClient http = new HttpClient();

        public async Task<IEnumerable<UserDto>> GetAllContactsAsync()
        {
            var response = await http.GetAsync("https://localhost:7118/api/User/getAll");
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content);
            }

            return new List<UserDto>();
        }
    }
}
