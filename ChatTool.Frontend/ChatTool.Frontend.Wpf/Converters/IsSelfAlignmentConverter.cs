namespace ChatTool.Frontend.Wpf.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows;

    public class IsSelfAlignmentConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 2 && values[0] is Guid senderId && values[1] is Guid selfId)
            {
                if (senderId == selfId)
                {
                    return HorizontalAlignment.Right;
                }
            }

            return HorizontalAlignment.Left;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
