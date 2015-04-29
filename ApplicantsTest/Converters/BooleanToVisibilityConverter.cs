using System;
using Windows.UI.Xaml.Data;

namespace ApplicantsTest.Converters
{
    using Windows.UI.Xaml;

    /// <summary>
    /// Converts a boolean value to visibility value and sets the visibility depending on the boolean value. 
    /// The true/false values are configurable to be able to correspond to different
    /// </summary>
    public class BooleanToVisibilityConverter : IValueConverter
    {
// ReSharper disable MemberCanBePrivate.Global
        /// <summary>
        /// Sets the visibility conversion when a value is true
        /// </summary>
        public Visibility True { get; set; }
        /// <summary>
        /// Sets the visibility conversion when a value is false
        /// </summary>
        public Visibility False { get; set; }
// ReSharper restore MemberCanBePrivate.Global

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value is bool && ((bool)value) ? True : False;

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}