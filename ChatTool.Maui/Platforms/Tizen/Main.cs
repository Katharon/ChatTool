// <copyright file="Program.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace ChatTool.Maui
{
    using Microsoft.Maui;
    using Microsoft.Maui.Hosting;
    using System;

    internal class Program : MauiApplication
    {
        /// <inheritdoc/>
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        /// <summary>
        /// .
        /// </summary>
        /// <param name="args">..</param>
        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
