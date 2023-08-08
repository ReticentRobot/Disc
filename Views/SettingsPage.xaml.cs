using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
//using LoginAPI.Models;
using Disc.Models;
using Disc.Services;

namespace Disc.Views
{
    [QueryProperty(nameof(LoginInfo), "LoginInfo")]
    public partial class SettingsPage : ContentPage
	{
		ILoginService _loginService;
		LoginInfo _loginInfo;

		public LoginInfo LoginInfo
		{
			get => _loginInfo;
			set
			{
				_loginInfo = value;
				OnPropertyChanged();
			}
		}

		public SettingsPage(ILoginService service)
		{
			InitializeComponent();
			_loginService = service;
			BindingContext = this;
		}

		async void OnLoginButtonClicked(object sender, EventArgs e)
		{
			await _loginService.LoginAsync(LoginInfo);
			await Shell.Current.GoToAsync("..");
		}
    }
}