using System.Globalization;
using System.Diagnostics;

namespace Disc.Converters
{
    public class LinkTypeImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Check if the value is a string
            if (value is string type)
            {
                Debug.WriteLine("Post Type: " + type);
                // Return the corresponding image file name based on the type
                switch (type)
                {
                    case "text":
                        return "icon_text_link.png";
                    case "image":
                        return "icon_image_link.png";
                    case "link":
                        return "icon_site_link.png";
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