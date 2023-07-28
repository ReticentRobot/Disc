using Disc.Models;
using Disc.Services;
using System.Collections.ObjectModel;

namespace Disc.Views
{
    [QueryProperty(nameof(Posts), "Posts")]
    public partial class PostsPage // : ContentPage
    {
        IPostsService _postsService;
        Post _posts;
        //bool _isNewItem;

        public Post Posts
        {
            get => _posts;
            set
            {
                //_isNewItem = IsNewItem(value);
                _posts = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<Post> PostList { get; set; }

        public PostsPage(IPostsService service)
        {
            InitializeComponent();
            _postsService = service;
            BindingContext = this;
        }

        /*
        bool IsNewItem(Post Posts)
        {
            if (string.IsNullOrWhiteSpace(Posts.Title) && string.IsNullOrWhiteSpace(Post.Body))
                return true;
            return false;
        }
        */
    }
}