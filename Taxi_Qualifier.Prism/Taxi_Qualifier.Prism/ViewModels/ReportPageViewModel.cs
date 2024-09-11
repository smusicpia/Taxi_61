using System;
using System.Collections.Generic;
using System.Linq;

using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace Taxi_Qualifier.Prism.ViewModels
{
    public class ReportPageViewModel : ViewModelBase
    {
        public ReportPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Report an incident";
        }
    }
}
