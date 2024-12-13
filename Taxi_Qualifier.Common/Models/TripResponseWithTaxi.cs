namespace Taxi_Qualifier.Common.Models
{
    public class TripResponseWithTaxi : TripResponse
    {
        public TaxiResponse Taxi { get; set; }
    }
}
