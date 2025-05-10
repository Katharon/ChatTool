namespace ChatTool.Backend.Application.Users.DTOs
{
    public class RegisterDto
    {
        public string Email { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string PublicKeyBase64 { get; set; } = string.Empty;
    }
}
