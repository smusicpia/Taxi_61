﻿using System.Collections.Generic;
using System.Threading.Tasks;

using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

using Taxi_Qualifier.Common.Services;

using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Taxi_Qualifier.Prism.Views
{
    public partial class HomePage : ContentPage
    {
        private readonly IGeolocatorService _geolocatorService;

        private void MoveMap(Position position)
        {
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(
                position,
                Distance.FromKilometers(.2)));
        }


        public HomePage(IGeolocatorService geolocatorService)
        {
            InitializeComponent();
            _geolocatorService = geolocatorService;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MoveMapToCurrentPositionAsync();
        }

        private async void MoveMapToCurrentPositionAsync()
        {
            bool isLocationPermision = await CheckLocationPermisionsAsync();

            if (isLocationPermision)
            {
                MyMap.IsShowingUser = true;

                await _geolocatorService.GetLocationAsync();
                if (_geolocatorService.Latitude != 0 && _geolocatorService.Longitude != 0)
                {
                    Position position = new Position(
                        _geolocatorService.Latitude,
                        _geolocatorService.Longitude);
                    MoveMap(position);
                }
            }
        }

        private async Task<bool> CheckLocationPermisionsAsync()
        {
            var permissionLocationAlways = await Permissions.CheckStatusAsync<Permissions.LocationAlways>();
            var permissionLocationWhenInUse = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            bool isLocationEnabled = permissionLocationAlways == Xamarin.Essentials.PermissionStatus.Granted ||
                                     permissionLocationWhenInUse == Xamarin.Essentials.PermissionStatus.Granted;

            //PermissionStatus permissionLocation = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
            //PermissionStatus permissionLocationAlways = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationAlways);
            //PermissionStatus permissionLocationWhenInUse = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationWhenInUse);
            //bool isLocationEnabled = permissionLocation == PermissionStatus.Granted ||
            //                            permissionLocationAlways == PermissionStatus.Granted ||
            //                            permissionLocationWhenInUse == PermissionStatus.Granted;

            if (isLocationEnabled)
            {
                return true;
            }

            //await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);

            //permissionLocation = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
            //permissionLocationAlways = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationAlways);
            //permissionLocationWhenInUse = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationWhenInUse);
            //return permissionLocation == PermissionStatus.Granted ||
            //        permissionLocationAlways == PermissionStatus.Granted ||
            //        permissionLocationWhenInUse == PermissionStatus.Granted;

            permissionLocationAlways = await Permissions.RequestAsync<Permissions.LocationAlways>();
            permissionLocationWhenInUse = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            isLocationEnabled = permissionLocationAlways == Xamarin.Essentials.PermissionStatus.Granted ||
                                permissionLocationWhenInUse == Xamarin.Essentials.PermissionStatus.Granted;

            if (isLocationEnabled)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
