using System;
using System.Collections.Generic;
using System.Linq;

using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

using Taxi_Qualifier.Common.Models;

namespace Taxi_Qualifier.Prism.ViewModels
{
    public class TripDetailPageViewModel : ViewModelBase
    {
        private TripResponse _trip;

        public TripDetailPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Tripv Detail";
        }

        public TripResponse Trip
        {
            get => _trip;
            set => SetProperty(ref _trip, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("trip"))
            {
                Trip = parameters.GetValue<TripResponse>("trip");
            }
        }
    }

}
