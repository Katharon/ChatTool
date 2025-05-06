namespace ChatTool.Frontend.Wpf.ViewModels
{
    using ChatTool.Frontend.Wpf.Models;
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Media.Imaging;

    class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            var bubuImage = new BitmapImage(new Uri("pack://application:,,,/ChatTool.Frontend.Wpf;component/Resources/Images/Bubu.png"));
            var alexImage = new BitmapImage(new Uri("pack://application:,,,/ChatTool.Frontend.Wpf;component/Resources/Images/Alex.png"));
            var patrickImage = new BitmapImage(new Uri("pack://application:,,,/ChatTool.Frontend.Wpf;component/Resources/Images/Patrick.png"));

            this.Contacts =
            [
                new ("Bubu", "Bin bald da.", bubuImage, DateTime.Now, DateTime.Now),
                new ("Alex", "Wann gehst trainieren?", alexImage, DateTime.Now, DateTime.Now),
                new ("Patrick", "Bock auf Monsterhunter?", patrickImage, DateTime.Now, DateTime.Now),
            ];
        }

        public ObservableCollection<Contact> Contacts { get; set; }

        public Contact? SelectedContact { get; set; }
    }
}
