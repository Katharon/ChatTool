namespace ChatTool.Backend.Persistence.Entities
{
    using Microsoft.AspNetCore.Identity;
    using System;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public string PublicKeyBase64 { get; set; } = string.Empty;
    }
}
