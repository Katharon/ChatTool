﻿namespace ChatTool.Backend.Application.Users.DTOs
{
    using System;

    public class UserDto
    {
        public Guid Id { get; set; }
        public string PublicKeyBase64 { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
    }
}
