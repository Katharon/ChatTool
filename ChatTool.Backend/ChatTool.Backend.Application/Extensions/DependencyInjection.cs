namespace ChatTool.Backend.Application.Extensions
{
    using ChatTool.Backend.Application.Messages.Interfaces;
    using ChatTool.Backend.Application.Messages.Services;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IMessageService, MessageService>();

            return services;
        }
    }
}
