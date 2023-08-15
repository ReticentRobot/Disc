using Disc.ViewModels;
using Disc.Services;
using Microsoft.Maui.Layouts;

namespace Disc.Views;
public partial class HomePage : ContentPage
{
    PostsViewModel vm;

    public class LinkInfo 
    { 
        public string LinkUrl { get; set; } 
        public string ImageUrl { get; set; } 
    }

    public HomePage(IServiceProvider serviceProvider)
    {
        var restService = serviceProvider.GetService<RestService>();
        BindingContext = vm = new PostsViewModel(serviceProvider);
        InitializeComponent();
    }

    protected async override void OnAppearing()
    {
        await vm.LoadPosts();
    }

    bool IsLoadingMoreItems = false;
    async void OnCollectionViewRemainingItemsThresholdReached(object sender, EventArgs e)
    {
        if (IsLoadingMoreItems) return;

        IsLoadingMoreItems = true;
        
        Console.WriteLine("+++++++++++++++++");
        Console.WriteLine("Threshold reached");
        Console.WriteLine("+++++++++++++++++");
        await vm.LoadPosts();

        IsLoadingMoreItems = false;
    }

    async void OnTapGestureRecognizerTapped(object sender, TappedEventArgs args)
    {

        LinkInfo linkInfo = new LinkInfo();
        linkInfo.LinkUrl = args.Parameter as string;

        if (linkInfo.LinkUrl != null)
        {
            Console.WriteLine("Link URL: " + linkInfo.LinkUrl);

            //Check to see if URL is a direct image
            var extension = Path.GetExtension(linkInfo.LinkUrl);
            Console.WriteLine("Link Extension: " + extension);
            if (extension == ".jpg" || extension == ".png" || extension == ".gif" || extension == ".bmp")
            {
                // Create a new Models.Link object and set its LinkUrl property to the linkInfo.LinkUrl value
                Models.Link link = new Models.Link();
                link.LinkUrl = linkInfo.LinkUrl;

                // Create a new ImageViewModel object and pass the link.LinkUrl property to its constructor
                var VM = new ImageViewModel(link.LinkUrl);

                // Push the WebViewPage onto the navigation stack
                await Application.Current.MainPage.Navigation.PushModalAsync(new ImagePage(VM));
            }
            else
            {
                // Create a new Models.Link object and set its LinkUrl property to the linkInfo.LinkUrl value
                Models.Link link = new Models.Link();

                link.LinkUrl = linkInfo.LinkUrl;

                // Create a new WebViewViewModel object and pass the link.LinkUrl property to its constructor
                var VM = new WebViewViewModel(link.LinkUrl);

                // Push the WebViewPage onto the navigation stack
                await Application.Current.MainPage.Navigation.PushModalAsync(new WebViewPage(VM));
            }
        }
        else
        {
            Console.WriteLine("Link is null");
        }
        
    }
}