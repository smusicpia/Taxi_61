using System;
using System.Collections.Generic;
using System.Linq;

using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace Taxi_Qualifier.Prism.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        public LoginPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Login";
        }
    }
}
