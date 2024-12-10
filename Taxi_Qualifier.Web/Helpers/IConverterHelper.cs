using Taxi.Web.Data.Entities;

using Taxi_Qualifier.Common.Models;
using Taxi_Qualifier.Web.Data.Entities;

namespace Taxi_Qualifier.Web.Helpers
{
    public interface IConverterHelper
    {
        TaxiResponse ToTaxiResponse(TaxiEntity taxiEntity);

        TripResponse ToTripResponse(TripEntity tripEntity);
    }
}
