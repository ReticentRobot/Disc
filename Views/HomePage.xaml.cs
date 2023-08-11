using Disc.ViewModels;
using Disc.Models;

namespace Disc.Views;
public partial class HomePage : ContentPage
{
    PostsViewModel vm;

    public class LinkInfo 
    { 
        public string LinkUrl { get; set; } 
        public string ImageUrl { get; set; } 
    }

    public HomePage()
    {
        BindingContext = vm = new PostsViewModel();
        InitializeComponent();
    }

    protected async override void OnAppearing()
    {
        //string next = vm.Data.Next;
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

        if (linkInfo != null)
        {
            Console.WriteLine("LinkInfo is not null: " + linkInfo);
            Console.WriteLine("LinkInfo URL: " + linkInfo.LinkUrl);
            // Create a new Disc.Models.Link object and set its LinkUrl property to the linkInfo.LinkUrl value
            Disc.Models.Link link = new Disc.Models.Link();

            link.LinkUrl = linkInfo.LinkUrl;
            Console.WriteLine("Link URL: " + link.LinkUrl);
            // Create a new WebViewViewModel object and pass the link.LinkUrl property to its constructor
            var VM = new WebViewViewModel(link.LinkUrl);
            // Push the WebViewPage onto the navigation stack
            await Application.Current.MainPage.Navigation.PushModalAsync(new WebViewPage(VM));
        }
        else
        {
            Console.WriteLine("Link is null");
        }
        
    }
}