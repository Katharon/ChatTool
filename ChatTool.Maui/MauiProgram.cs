// <copyright file="MauiProgram.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace ChatTool.Maui
{
    using ChatTool.Maui.PageModels;
    using ChatTool.Maui.Pages;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// .
    /// </summary>
    public static class MauiProgram
    {
        /// <summary>
        /// .
        /// </summary>
        /// <returns>..</returns>
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Page Models
            builder.Services.AddTransient<MainPageModel>();

            // Pages
            builder.Services.AddTransient<MainPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
