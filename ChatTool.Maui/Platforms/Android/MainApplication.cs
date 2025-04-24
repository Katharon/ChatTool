// <copyright file="MainApplication.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace ChatTool.Maui
{
    using Android.App;
    using Android.Runtime;

    /// <summary>
    /// .
    /// </summary>
    [Application]
    public class MainApplication : MauiApplication
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainApplication"/> class.
        /// </summary>
        /// <param name="handle">.</param>
        /// <param name="ownership">..</param>
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
        }

        /// <inheritdoc/>
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
