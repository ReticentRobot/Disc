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

    public bool IsLoadingMoreItems = true;
    async void OnCollectionViewRemainingItemsThresholdReached(object sender, EventArgs e)
    {
        if(IsLoadingMoreItems == true)
        {
            Console.WriteLine("+++++++++++++++++");
            Console.WriteLine("Threshold reached");
            Console.WriteLine("+++++++++++++++++");
            await vm.LoadPosts();
            IsLoadingMoreItems = false;
        }
        //await Task.Run(() => vm.FetchNextData());
    }

}