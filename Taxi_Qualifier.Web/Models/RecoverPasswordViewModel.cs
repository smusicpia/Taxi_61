using System.ComponentModel.DataAnnotations;

namespace Taxi_Qualifier.Web.Models
{
    public class RecoverPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }

}
