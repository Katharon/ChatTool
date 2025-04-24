// <copyright file="MainPage.xaml.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace ChatTool.Maui.Pages
{
    using ChatTool.Maui.PageModels;

    /// <summary>
    /// .
    /// </summary>
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        /// <param name="pageModel">.</param>
        public MainPage(MainPageModel pageModel)
        {
            this.InitializeComponent();
            this.BindingContext = pageModel;
        }
    }
}
