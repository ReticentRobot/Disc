﻿using Disc.Views;

namespace Disc;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(PostsPage), typeof(PostsPage));
	}
}