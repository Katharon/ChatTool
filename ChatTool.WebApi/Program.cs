// <copyright file="Program.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace ChatTool.WebApi
{
    using ChatTool.Dependencies;
    using ChatTool.Infrastructure.Mappings;
    using Scalar.AspNetCore;

    /// <summary>
    /// The main entry point of the Web API application.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Starts the Web API application with configured services and HTTP pipeline.
        /// </summary>
        /// <param name="args">Command-line arguments passed to the application.</param>
        internal static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            builder.Services.AddDependencies(builder.Configuration);
            builder.Services.AddAutoMapper(typeof(UserProfile).Assembly);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference(options => options.Title = "ChatTool API");
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}