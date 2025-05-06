namespace ChatTool.Backend.Application.Users.Services
{
    using ChatTool.Backend.Application.Users.DTOs;
    using System.Net.Http.Json;
    using System.Threading.Tasks;

    public class AuthService
    {
        private readonly HttpClient http = new HttpClient();

        public async Task<bool> RegisterAsync(RegisterDto dto)
        {
            var response = await http.PostAsJsonAsync("https://localhost:7118/api/Auth/register", dto);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> LoginAsync(LoginDto dto)
        {
            var response = await http.PostAsJsonAsync("https://localhost:7118/api/Auth/login", dto);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}
