namespace Disc.Views;

public partial class AboutPage : ContentPage
{
	public AboutPage()
	{
        InitializeComponent();
    }

    private async void LearnMore_Clicked(object sender, EventArgs e)
    {
        // Navigate to the specified URL in the system browser.
        await Launcher.Default.OpenAsync("https://discuit.net");
    }

    private async void Logo_Clicked(object sender, EventArgs e)
    {
        // Navigate to the specified URL in the system browser.
        await Launcher.Default.OpenAsync("https://www.reticentrobot.com");
    }
}

