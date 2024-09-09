using System.Collections.Generic;

using Taxi_Qualifier.Web.Data.Entities;

namespace Taxi.Web.Data.Entities
{
    public class UserGroupEntity
    {
        public int Id { get; set; }

        public UserEntity User { get; set; }

        public ICollection<UserEntity> Users { get; set; }
    }
}