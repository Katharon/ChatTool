namespace ChatTool.Backend.Application.Users.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IUserService
    {
        Guid Id { get; }

        string? Email { get; }

        bool IsAuthenticated { get; }
    }
}
