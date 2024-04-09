using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Plugin.Fingerprint.Abstractions;
using Plugin.Fingerprint;
using projectFr.Constant;
#if ANDROID
using Android.Text;
using Android.Content;
using Android.Locations;
#endif

namespace projectFr.ViewModdels
{
    partial class LockViewModdel : ObservableObject
    {
        #region Varible
        string togle = Preferences.Default.Get(AppConst.IsBio, "True"); 
        #endregion

        #region Methods
        [RelayCommand]
        async Task FingerClicAsync()
        {
            bool en = IsGpsEnable();
            var isAvailable = await CrossFingerprint.Current.IsAvailableAsync();
            PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if (en == true)
            {
                if (isAvailable & togle == "True")
                {
                    var request = new AuthenticationRequestConfiguration
                    ("Login using biometrics", "Confirm login with your biometrics");

                    var result = await CrossFingerprint.Current.AuthenticateAsync(request);

                    if (result.Authenticated)
                    {
                        await Shell.Current.GoToAsync("/Dashbord");
                    }
                    else
                    {
                        await Shell.Current.DisplayAlert("Not authenticated!", "Access denied", "OK");
                    }
                }
                else
                {
                    await Shell.Current.DisplayAlert("Info", "Access denied Use PIN", "OK");
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("INFO", "Pleas Open Location and Try agin", "Ok"); ;
            }
            // check if gps enaable or disable 
            bool IsGpsEnable()
            {
#if ANDROID
                LocationManager locationManager = (LocationManager)Android.App.Application.Context.GetSystemService(Context.LocationService);
                return locationManager.IsProviderEnabled(LocationManager.GpsProvider);
#endif
                return true;
            }
        } 
#endregion
    }
}
