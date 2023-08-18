using System.Globalization;
using System.Diagnostics;

namespace Disc.Converters
{
    public class UsernameColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                // Check if the value is a string
                if (value is string name)
                {
                    // Use a switch statement to return a different color based on the name
                    switch (name)
                    {
                        case "Previnder":
                            return Colors.OrangeRed;
                        case "ReticentRobot":
                            return Colors.SkyBlue;
                        case "TestAccountPlsIgnore":
                            return Colors.SkyBlue;
                        case "Felix30":
                            return Colors.SkyBlue;
                        case "RenegadeBAM":
                            return Colors.SkyBlue;
                        case "gsurfer04":
                            return Colors.SkyBlue;
                        case "Keukotis":
                            return Colors.SkyBlue;
                        default:
                            return Colors.AntiqueWhite;
                    }
                }
                // Return a default color if the value is not a string
                return Colors.White;
            }
            
            catch (NullReferenceException e)
            {
                Debug.WriteLine("Null Reference Exception Caught: " + e);
                return null;
            } 
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // This converter does not support converting back from color to name
            throw new NotImplementedException();
        }
    }
}