using Disc.Models;
using Disc.Services;

namespace Disc.Views
{
    [QueryProperty(nameof(PostItem), "PostItem")]
    public partial class PostPage : ContentPage
    {
        IPostService _postService;
        PostItem _postItem;
        bool _isNewItem;

        public PostItem PostItem
        {
            get => _postItem;
            set
            {
                _isNewItem = IsNewItem(value);
                _postItem = value;
                OnPropertyChanged();
            }
        }

        public PostPage(IPostService service)
        {
            InitializeComponent();
            _postService = service;
            BindingContext = this;
        }

        bool IsNewItem(PostItem PostItem)
        {
            if (string.IsNullOrWhiteSpace(PostItem.Title) && string.IsNullOrWhiteSpace(PostItem.Body))
                return true;
            return false;
        }
    }
}