using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

//using Plugin.Permissions.Abstractions;

using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

using Xamarin.Essentials;
using Xamarin.Forms;

namespace Taxi_Qualifier.Prism.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        public HomePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Taxi Qualifier";
        }
    }
}
