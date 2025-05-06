namespace ChatTool.Backend.Application.Extensions
{
    using ChatTool.Backend.Application.Messages.Interfaces;
    using ChatTool.Backend.Application.Messages.Services;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

            //services.AddScoped<IMessageService, MessageService>();

            return services;
        }
    }
}
