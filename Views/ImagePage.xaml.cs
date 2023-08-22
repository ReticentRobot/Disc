using Disc.ViewModels;

namespace Disc.Views;

public partial class ImagePage : ContentPage
{
    public ImagePage(ImageViewModel VM)
    {
        InitializeComponent();
        this.BindingContext = VM;
    }
}