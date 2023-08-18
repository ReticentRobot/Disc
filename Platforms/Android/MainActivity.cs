using Android.App;
using Android.Content.PM;

namespace Disc;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    /* REMOVES TOP ANDROID BAR WITH TIME, BATTERY, ETC.
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        Platform.Init(this, savedInstanceState);

        this.Window.AddFlags(WindowManagerFlags.Fullscreen);
    }
    */
}
