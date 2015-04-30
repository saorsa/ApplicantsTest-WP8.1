using System;

namespace ApplicantsTest.Converters
{
    using Windows.UI.Xaml.Data;
    /// <summary>
    /// Inverts a boolean value.
    /// </summary>
    public class InverseBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (targetType != typeof(bool))
                throw new ArgumentException("The target value in inverse boolean conversion should be of type bool.","value");

            return !(bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
