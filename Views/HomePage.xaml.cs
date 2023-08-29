using Disc.Services;
using Disc.ViewModels;
using Microsoft.Maui.Controls;
using Sentry;
using System.Diagnostics;

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
        //PostsCollection.ScrollTo(0);
    }

    bool IsLoadingMoreItems = false;
    async void OnCollectionViewRemainingItemsThresholdReached(object sender, EventArgs e)
    {
        if (IsLoadingMoreItems) return;
        IsLoadingMoreItems = true;

        Debug.WriteLine("+++++++++++++++++");
        Debug.WriteLine("Threshold reached");
        Debug.WriteLine("+++++++++++++++++");
        await vm.LoadPosts();

        IsLoadingMoreItems = false;
    }

    private void OnChevronClicked(object sender, EventArgs e)
    { 
        // Get the image object
        ImageButton imageButton = sender as ImageButton;

        // Get the current row of the image
        int currentRow = Grid.GetRow(imageButton);

        // Get the next row
        int nextRow = currentRow + 1;

        // Add a new row definition to the grid
        Grid PostsGrid = this.FindByName<Grid>("PostsGrid"); PostsGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });

        // Set the row of the image to the next row
        Grid.SetRow(imageButton, nextRow); 
    }

    async void OnTapGestureRecognizerTapped(object sender, TappedEventArgs args)
    {
        LinkInfo linkInfo = new LinkInfo();
        linkInfo.LinkUrl = args.Parameter as string;

        if (linkInfo.LinkUrl != null)
        {
            Debug.WriteLine("Link URL: " + linkInfo.LinkUrl);

            //Check to see if URL is a direct image
            var extension = Path.GetExtension(linkInfo.LinkUrl);
            Debug.WriteLine("Link Extension: " + extension);
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
            Debug.WriteLine("Link was null");
            //SentrySdk.CaptureMessage("Link was null in OnTapGestureRecognizerTapped()");
        }

    }
}