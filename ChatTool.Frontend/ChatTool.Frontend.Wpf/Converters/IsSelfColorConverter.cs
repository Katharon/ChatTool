namespace ChatTool.Frontend.Wpf.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Media;
    using System.Windows;

    public class IsSelfColorConverter : IValueConverter
    {
        public Guid SelfId { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Guid senderId)
            {
                return senderId == SelfId
                    ? new SolidColorBrush((Color)ColorConverter.ConvertFromString("#005c4b")) // eigene Nachricht
                    : new SolidColorBrush((Color)ColorConverter.ConvertFromString("#353535")); // fremde Nachricht
            }

            return HorizontalAlignment.Left;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
