using System;
using System.Collections.Generic;
using System.Text;

namespace Taxi_Qualifier.Common.Models
{
    public class TripResponseWithTaxi : TripResponse
    {
        public TaxiResponse Taxi { get; set; }
    }
}
