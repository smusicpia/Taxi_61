using Prism.Commands;
using Prism.Navigation;

using Taxi_Qualifier.Common.Models;
using Taxi_Qualifier.Prism.Views;

namespace Taxi_Qualifier.Prism.ViewModels
{
    public class TripItemViewModel : TripResponse
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectTripCommand;

        public TripItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectTripCommand => _selectTripCommand ?? (_selectTripCommand = new DelegateCommand(SelectTripAsync));

        private async void SelectTripAsync()
        {
            NavigationParameters parameters = new NavigationParameters
            {
                { "trip", this }
            };

            await _navigationService.NavigateAsync(nameof(TripDetailPage), parameters);
        }
    }

}
