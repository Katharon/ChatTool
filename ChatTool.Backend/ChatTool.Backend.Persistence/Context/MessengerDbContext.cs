namespace ChatTool.Backend.Persistence.Context
{
    using ChatTool.Backend.Domain.Models;
    using ChatTool.Backend.Persistence.Entities;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System;

    internal class MessengerDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public MessengerDbContext(DbContextOptions<MessengerDbContext> options)
            : base(options)
        {
        }

        internal DbSet<Message> Messages => Set<Message>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
