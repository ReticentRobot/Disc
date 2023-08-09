﻿using System.ComponentModel;
using Disc.Services;

namespace Disc;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

        // let's set the initial theme already during the app start
        SetTheme();

        // subscribe to changes in the settings
        SettingsService.Instance.PropertyChanged += OnSettingsPropertyChanged;
    }
}

private void OnSettingsPropertyChanged(object sender, PropertyChangedEventArgs e)
{
    if (e.PropertyName == nameof(SettingsService.Theme))
    {
        SetTheme();
    }
}

private void SetTheme()
{
    UserAppTheme = SettingsService.Instance?.Theme != null
                 ? SettingsService.Instance.Theme.AppTheme
                 : AppTheme.Unspecified;
}
