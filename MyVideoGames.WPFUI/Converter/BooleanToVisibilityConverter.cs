using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MyVideoGames.WPFUI.Converter
{
    // Converter permettant de transformer un Boolean en Propriété de Visibilité
    public class BooleanToVisibilityConverter : IValueConverter
    {
        // Fonction de conversion Bool => Visibility
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool boolValue = (bool)value;
            boolValue = parameter != null ? !boolValue : boolValue;
            return boolValue ? Visibility.Visible : Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}