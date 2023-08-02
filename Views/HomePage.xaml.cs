using CommunityToolkit.Mvvm.Input;
using Disc.ViewModels;

namespace Disc.Views;
public partial class HomePage : ContentPage
{
    PostsViewModel vm;

    public HomePage()
    {
        InitializeComponent();
        BindingContext = vm = new PostsViewModel();
    }

    protected async override void OnAppearing()
    {
        await vm.LoadPosts();
    }

}