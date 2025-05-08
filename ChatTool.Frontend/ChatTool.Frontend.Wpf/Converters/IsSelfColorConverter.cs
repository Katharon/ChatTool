namespace ChatTool.Frontend.Wpf.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Media;

    public class IsSelfColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 2 && values[0] is Guid senderId && values[1] is Guid selfId)
            {
                if (senderId == selfId)
                {
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#005c4b"));
                }
            }

            return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#383838"));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
