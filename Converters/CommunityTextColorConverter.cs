using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace Disc.Converters
{
    public class CommunityTextColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length != 2)
            {
                Console.WriteLine("CommunityTextColorConverter: values is null or values.Length != 2");
                return null;
            }
       
            string text = values[0] as string;
            //Console.WriteLine("CommunityText Value: " + text);
            Color defaultColor = (Color)values[1];

            if (text == "CommunityName")
                return Colors.Red; // Change the text color to red if it's "Hello"
            else if (text == "Username")

            return Colors.Blue; // Change the text color to blue if it's "World"
            else
                return defaultColor; // Use the default color otherwise
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}