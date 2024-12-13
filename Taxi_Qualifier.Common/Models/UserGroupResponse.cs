using System.Collections.Generic;

namespace Taxi_Qualifier.Common.Models
{
    public class UserGroupResponse
    {
        public int Id { get; set; }

        public UserResponse User { get; set; }

        public List<UserGroupDetailResponse> Users { get; set; }
    }
}
