using System;
using Taxi_Qualifier.Common.Enums;

namespace Taxi_Qualifier.Web.Data.Entities
{
    public class UserGroupRequestEntity
    {
        public int Id { get; set; }

        public UserEntity ProposalUser { get; set; }

        public UserEntity RequiredUser { get; set; }

        public UserGroupStatus Status { get; set; }

        public Guid Token { get; set; }
    }
}
