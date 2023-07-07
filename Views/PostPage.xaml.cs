using Disc.Models;
using Disc.Services;

namespace Disc.Views
{
    [QueryProperty(nameof(PostItem), "PostItem")]
    public partial class PostItemPage : ContentPage
    {
        IPostService _PostService;
        PostItem _PostItem;
        bool _isNewItem;

        public PostItem PostItem
        {
            get => _PostItem;
            set
            {
                _isNewItem = IsNewItem(value);
                _PostItem = value;
                OnPropertyChanged();
            }
        }

        public PostItemPage(IPostService service)
        {
            InitializeComponent();
            _PostService = service;
            BindingContext = this;
        }

        bool IsNewItem(PostItem PostItem)
        {
            if (string.IsNullOrWhiteSpace(PostItem.title) && string.IsNullOrWhiteSpace(PostItem.body))
                return true;
            return false;
        }
    }
}