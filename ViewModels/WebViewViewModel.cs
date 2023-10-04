using Disc.Models;
using System.Windows.Input;
using System.Diagnostics;

namespace Disc.ViewModels
{
    public class WebViewViewModel : BaseViewModel
    {
        // Declare a property to store the link object
        public Link Link { get; set; }

        // Declare a constructor that takes a link parameter
        public WebViewViewModel(string linkUrl)
        {

            Debug.WriteLine("LinkUrl: " + linkUrl);
            // Create a new Link object and set its LinkUrl property to the linkUrl parameter
            Link link = new Link();

            // Assign the link object to the Link property

            link.LinkUrl = linkUrl;

            // Assign the link object to the Link property
            Link = link;

            // Initialize the GoBackCommand property
            GoBackCommand = new Command(async () => await Application.Current.MainPage.Navigation.PopModalAsync());
        }

        // Declare the GoBackCommand property
        public ICommand GoBackCommand { get; set; }
    }
}