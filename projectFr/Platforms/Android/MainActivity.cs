using Android.App;
using Android.Content.PM;
using Android.OS;
using Plugin.Fingerprint;

namespace projectFr
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    [assembly: UsesPermission(Manifest.Permission.AccessBackgroundLocation)]
    [assembly: UsesPermission(Android.Manifest.Permission.AccessCoarseLocation)]
    [assembly: UsesPermission(Android.Manifest.Permission.AccessFineLocation)]
    [assembly: UsesFeature("android.hardware.location", Required = false)]
    [assembly: UsesFeature("android.hardware.location.gps", Required = false)]
    [assembly: UsesFeature("android.hardware.location.network", Required = false)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            CrossFingerprint.SetCurrentActivityResolver(() => this);
        }
    }
}
