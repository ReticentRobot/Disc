using Disc.ViewModels;

namespace Disc.Views;
public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
        BindingContext = new PostsViewModel();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        PostsViewModel postsViewModel = new PostsViewModel();
        await postsViewModel.LoadPosts();
    }
}