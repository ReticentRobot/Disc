using System.Globalization; 
using Humanizer;
using Humanizer.Localisation;

namespace Disc.Converters
{ 
    public class CreatedAtConverter : IValueConverter 
    { 
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) 
        { 
            // Check if the value is a DateTime
            if (value is DateTime dateTime)
            {
                // Compare the value with the current time and get the difference as a TimeSpan
                TimeSpan difference = DateTime.UtcNow - dateTime;

                string humanizedTimespan = difference.Humanize(1, culture: new CultureInfo("en-US"));

                // Use the Humanize extension method to get a relative time string
                return humanizedTimespan;
            }
            // Return null if the value is not a DateTime
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
        // This converter does not support converting back from string to DateTime
            throw new NotImplementedException();
        }
    }
}