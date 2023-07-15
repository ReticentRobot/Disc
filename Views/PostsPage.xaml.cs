using Disc.Models;
using Disc.Services;

namespace Disc.Views
{
    [QueryProperty(nameof(Posts), "Posts")]
    public partial class PostsPage : ContentPage
    {
        IPostsService _postsService;
        Posts _posts;
        bool _isNewItem;

        public Posts Posts
        {
            get => _posts;
            set
            {
                _isNewItem = IsNewItem(value);
                _posts = value;
                OnPropertyChanged();
            }
        }

        public PostsPage(IPostsService service)
        {
            InitializeComponent();
            _postsService = service;
            BindingContext = this;
        }

        bool IsNewItem(Posts Posts)
        {
            if (string.IsNullOrWhiteSpace(Posts.Title) && string.IsNullOrWhiteSpace(Posts.Body))
                return true;
            return false;
        }
    }
}