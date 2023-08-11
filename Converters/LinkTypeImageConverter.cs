using System.Globalization;

namespace Disc.Converters
{
    public class LinkTypeImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Check if the value is a string
            if (value is string type)
            {
                // Return the corresponding image file name based on the type
                switch (type)
                {
                    case "text":
                        return "text_link_darkmode.png";
                    case "image":
                        return "image_link_darkmode.png";
                    case "link":
                        return "site_link_darkmode.png";
                    default:
                        return null;
                }
            }
            // Return null if the value is not a string
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // This converter does not support converting back
            throw new NotImplementedException();
        }
    }
}