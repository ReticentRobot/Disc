using Disc.Models;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Disc.ViewModels;

namespace Disc.Views;
public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
        BindingContext = new PostsViewModel();
    }
}