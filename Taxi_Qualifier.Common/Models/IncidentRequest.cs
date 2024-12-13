using System.ComponentModel.DataAnnotations;

namespace Taxi_Qualifier.Common.Models
{
    public class IncidentRequest : TripRequest
    {
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Remarks { get; set; }
    }

}
