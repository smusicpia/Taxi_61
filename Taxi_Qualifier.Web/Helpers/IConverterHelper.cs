using System.Collections.Generic;

using Taxi_Qualifier.Web.Data.Entities;

using Taxi_Qualifier.Common.Models;

namespace Taxi_Qualifier.Web.Helpers
{
    public interface IConverterHelper
    {
        TaxiResponse ToTaxiResponse(TaxiEntity taxiEntity);

        TripResponse ToTripResponse(TripEntity tripEntity);

        UserResponse ToUserResponse(UserEntity user);

        List<TripResponseWithTaxi> ToTripResponse(List<TripEntity> tripEntities);

        List<UserGroupDetailResponse> ToUserGroupResponse(List<UserGroupDetailEntity> users);
    }
}
