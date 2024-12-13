﻿using System.Collections.Generic;

namespace Taxi_Qualifier.Web.Data.Entities
{
    public class UserGroupEntity
    {
        public int Id { get; set; }

        public UserEntity User { get; set; }

        public ICollection<UserGroupDetailEntity> Users { get; set; }
    }
}