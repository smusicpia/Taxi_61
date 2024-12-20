﻿using System.Collections.Generic;
using System.Linq;

namespace Taxi_Qualifier.Common.Models
{
    public class TaxiResponse
    {
        public int Id { get; set; }

        public string Plaque { get; set; }

        public List<TripResponse> Trips { get; set; }

        public UserResponse User { get; set; }

        public float Qualification => Trips == null ? 0 : Trips.Average(t => t.Qualification);

        public int NumberOfTrips => Trips == null ? 0 : Trips.Count;
    }

}
