namespace ChatTool.Frontend.Wpf.Views
{
    using ChatTool.Frontend.Wpf.ViewModels;
    using System.Net.Http;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Input;
    using System.Windows.Media;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ScrollViewer? scrollViewer;
        private double animationTargetOffset;
        private double animationCurrentOffset;
        private bool isRenderingSubscribed = false;
        private const double wheelFactor = 0.50;
        private readonly MainWindowViewModel viewModel;

        public MainWindow(Guid selfId)
        {
            this.InitializeComponent();
            this.viewModel = new MainWindowViewModel();
            this.viewModel.SelfId = selfId;
            this.DataContext = viewModel;
            this.viewModel.MessageReceived += ScrollChatToBottom;
        }

        private void ScrollChatToBottom(object? sender, EventArgs e)
        {
            if (MessageListBox.Items.Count > 0)
            {
                MessageListBox.ScrollIntoView(MessageListBox.Items[MessageListBox.Items.Count - 1]);
            }
        }

        private void MessageTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // Erzwinge Binding-Aktualisierung
                var textBox = (TextBox)sender;
                var binding = BindingOperations.GetBindingExpression(textBox, TextBox.TextProperty);
                binding?.UpdateSource();

                this.viewModel.SendMessage();
            }
        }

        private void ChatList_Loaded(object sender, RoutedEventArgs e)
        {
            this.scrollViewer = (ScrollViewer)ChatList.Template.FindName("Scroller", ChatList);
            animationCurrentOffset = scrollViewer.VerticalOffset;
            ChatList.PreviewMouseWheel += ChatList_PreviewMouseWheel;
        }

        private void ChatList_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (scrollViewer == null) return;

            // ❷ Delta dämpfen
            double delta = -e.Delta * wheelFactor;       // „Rad nach unten“ → positive Pixel nach unten
            animationTargetOffset = scrollViewer.VerticalOffset + delta;

            // Grenzen einhalten
            animationTargetOffset = Math.Max(0, Math.Min(animationTargetOffset,
                                                         scrollViewer.ScrollableHeight));

            // Rendering‑Loop einschalten (wie gehabt)
            if (!isRenderingSubscribed)
            {
                CompositionTarget.Rendering += OnRender;
                isRenderingSubscribed = true;
            }

            e.Handled = true;     // verhindert das Standard‑Scrollen
        }

        private void OnRender(object? sender, EventArgs e)
        {
            if (scrollViewer == null) return;

            // Smooth scroll interpolation (easing-like)
            double speed = 0.4;
            animationCurrentOffset += (animationTargetOffset - animationCurrentOffset) * speed;

            if (Math.Abs(animationCurrentOffset - animationTargetOffset) < 0.5)
            {
                animationCurrentOffset = animationTargetOffset;
                CompositionTarget.Rendering -= OnRender;
                isRenderingSubscribed = false;
            }

            scrollViewer.ScrollToVerticalOffset(animationCurrentOffset);
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