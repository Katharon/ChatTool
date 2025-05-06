namespace ChatTool.Backend.Infrastructure.Extensions
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Beispiel: E-Mail-Versand, Cloud-Speicher, BackgroundJobs etc.
            // services.AddScoped<IEmailSender, EmailSender>();
            // services.Configure<BlobStorageOptions>(configuration.GetSection("Storage"));

            return services;
        }
    }
}
