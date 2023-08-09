using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace Disc.Converters
{
    public class NameColorMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Console.WriteLine("CommunityName: " + values[0]);
            Console.WriteLine("Username: " + values[1]);
            // Check if the input values are strings
            if (values[0] is not string community || values[1] is not string username)
                return Colors.Black;

            // Define an array of known community names
            string[] communities = new[] 
            { 
                "PlayStation", 
                "Xbox", 
                "PCGaming", 
                "Nintendo",
                "Discuit"
            };

            // Define a switch expression to map community names to colors
            Color communityColor = community switch
            {
                "PlayStation" => Colors.Blue,
                "Xbox" => Colors.Green,
                "PCGaming" => Colors.Purple,
                "Nintendo" => Colors.Red,
                "Discuit" => Colors.Purple,
                // Add more cases as needed
                _ => Colors.Aqua // Default case
            };

            // Define an array of known usernames
            string[] usernames = new[]
            {
                "Previnder",
                "ReticentRobot",
                "TestAccountPlsIgnore",
                "RenegadeBAM",
                "gsurfer04"
            };

            // Define a switch expression to map usernames to colors
            Color usernameColor = username switch
            {
                "Previnder" => Colors.Red,
                "ReticentRobot" => Colors.Orange,
                "TestAccountPlsIgnore" => Colors.Orange,
                "RenegadeBAM" => Colors.Orange,
                "gsurfer04" => Colors.Orange,
                // Add more cases as needed
                _ => Colors.Pink // Default case
            };

            // Return the color for the community name or the username based on the parameter value
            return parameter switch
            {
                "community" => communityColor,
                "username" => usernameColor,
                _ => Colors.AntiqueWhite // Default case
            };
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            // This converter does not support converting back
            throw new NotImplementedException();
        }
    }
}