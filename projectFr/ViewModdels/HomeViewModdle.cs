using System;
using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace projectFr.ViewModdels
{
    partial class HomeViewModdle : ObservableObject
    {
        #region Prop
        private CancellationTokenSource _cancelTokenSource;
        private bool _isCheckingLocation; 
        #endregion

        #region Cons
        public HomeViewModdle()
        {
            GetCurrentLocation();

        } 
        #endregion

        #region Methodes
        [RelayCommand]
        void onClick()
        {
            Shell.Current.GoToAsync("/Setting");
        }
        [RelayCommand]
        async void onLogin()
        {
            bool isavalible = await Launcher.Default.TryOpenAsync("https://www.dinewme.com/login");

            if (isavalible)
            {
                await Launcher.Default.OpenAsync("https://www.dinewme.com/login");
            }
        }
        public async void GetCurrentLocation()
        {
            try
            {
                _isCheckingLocation = true;

                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

                _cancelTokenSource = new CancellationTokenSource();

                Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

                if (location != null)
                    Geo(location);
            }
            // Catch one of the following exceptions:
            //   FeatureNotSupportedException
            //   FeatureNotEnabledException
            //   PermissionException
            catch (Exception ex)
            {
                // Unable to get location
            }
            finally
            {
                _isCheckingLocation = false;

            }
        }

        public void CancelRequest()
        {
            if (_isCheckingLocation && _cancelTokenSource != null && _cancelTokenSource.IsCancellationRequested == false)
                _cancelTokenSource.Cancel();
        }

        static async void Geo(Location location)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post,
                $"https://dinewme.com/App/SetGeoCoordinates?userTokenId=7Uxcrm4RMwkfo%2fMhyyx4db%2bERUCNlhyLt%2bkg4MA3%2bbARWJLOiB8JGv74FaNBQIGn&latitude={location.Latitude}&longitude={location.Longitude}");

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }
    } 
    #endregion
}
