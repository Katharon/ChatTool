namespace ChatTool.Frontend.Wpf.Views
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;

    /// <summary>
    /// Interaktionslogik für AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        private readonly HttpClient httpClient = new ()
        {
            BaseAddress = new Uri("https://localhost:7118/")
        };

        public AuthWindow()
        {
            InitializeComponent();
        }

        private async void SignIn_Click(object sender, RoutedEventArgs e)
        {
            // Neues anonymes Objekt
            var user = new
            {
                email = this.EmailInput.Text,
                password = this.PasswordInput.Text,
            };

            // In JSON umwandeln
            var json = JsonSerializer.Serialize(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await this.httpClient.PostAsync("/api/Auth/login", content);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<JsonElement>();
                Guid selfId = result.GetProperty("id").GetGuid();
                new MainWindow(selfId).Show();
                this.Close();
            }
            else
            {
                MessageBox.Show($"Fehler: {response.StatusCode}");
            }
        }

        private async void SignUp_Click(object sender, RoutedEventArgs e)
        {
            // Neues anonymes Objekt
            var user = new
            {
                email = this.EmailInput.Text,
                userName = this.UsernameInput.Text,
                password = this.PasswordInput.Text,
            };

            // In JSON umwandeln
            var json = JsonSerializer.Serialize(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await this.httpClient.PostAsync("/api/Auth/register", content);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Registrierung erfolgreich!");
            }
            else
            {
                MessageBox.Show($"Fehler: {response.StatusCode}");
            }
        }

        private void Header_MouseLeftButtonDown(object sender, MouseButtonEventArgs eventArgs)
        {
            if (eventArgs.ButtonState == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = (WindowState == WindowState.Maximized) ? WindowState.Normal : WindowState.Maximized;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs eventArgs)
        {

        }
    }
}
