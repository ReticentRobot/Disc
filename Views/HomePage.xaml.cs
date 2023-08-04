using CommunityToolkit.Mvvm.Input;
using Disc.ViewModels;
using Disc.Models;
using RestSharp;
using System.Net;
using System.Text.Json;

namespace Disc.Views;
public partial class HomePage : ContentPage
{
    PostsViewModel vm;

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

    async void OnCollectionViewRemainingItemsThresholdReached(object sender, EventArgs e)
    {
        Console.WriteLine("Threshold Reached");
        await Task.Run(() => vm.FetchNextData());
    }

}