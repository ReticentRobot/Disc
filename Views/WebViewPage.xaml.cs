using Disc.ViewModels;

namespace Disc.Views;

public partial class WebViewPage : ContentPage
{
    public WebViewPage(WebViewViewModel VM)
    {
        InitializeComponent();
        this.BindingContext = VM;
    }
}