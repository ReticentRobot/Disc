using Microsoft.Maui.Controls;
using Disc.Models;
using Disc.Services;

namespace Disc.Views
{
    public partial class PostListPage : ContentPage
    {
        IPostService _PostService;

        public PostListPage(IPostService service)
        {
            InitializeComponent();
            _PostService = service;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await _PostService.GetTasksAsync();
        }

        async void OnAddItemClicked(object sender, EventArgs e)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { nameof(PostItem), new PostItem { id = Guid.NewGuid().ToString() } }
            };
            await Shell.Current.GoToAsync(nameof(PostItemPage), navigationParameter);
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { nameof(PostItem), e.CurrentSelection.FirstOrDefault() as PostItem }
            };
            await Shell.Current.GoToAsync(nameof(PostItemPage), navigationParameter);
        }
    }
}