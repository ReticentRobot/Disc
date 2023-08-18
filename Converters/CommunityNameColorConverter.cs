using System.Globalization;

namespace Disc.Converters
{
    public class CommunityNameColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                // Check if the value is a string
                if (value is string name)
                {
                    // Use a switch statement to return a different color based on the name
                    switch (name.ToLower())
                    {
                        case "discuit":
                            return Colors.SlateBlue;
                        case "discuitmeta":
                            return Colors.SlateBlue;
                        case "nintendo":
                            return Colors.Red;
                        case "xbox":
                            return Colors.Green;
                        case "playstation":
                            return Colors.DodgerBlue;
                        case "pcgaming":
                            return Colors.MediumOrchid;
                        case "gaming":
                            return Colors.Orange;
                        default:
                            return Colors.MediumSlateBlue;
                    }
                }
                // Return a default color if the value is not a string
                return Colors.LightGrey;
            }
            // Return a default color if the value is null
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // This converter does not support converting back from color to name
            throw new NotImplementedException();
        }
    }
}