using Disc.Models;
using Disc.Services;

namespace Disc.Views
{
    public partial class HomePage : ContentPage
    {
        IPostService _PostService;

        public HomePage(IPostService service)
        {
            InitializeComponent();
            _PostService = service;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await _PostService.GetTasksAsync();
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { nameof(PostItem), e.CurrentSelection.FirstOrDefault() as PostItem }
            };
            await Shell.Current.GoToAsync(nameof(PostPage), navigationParameter);
        }
    }
}