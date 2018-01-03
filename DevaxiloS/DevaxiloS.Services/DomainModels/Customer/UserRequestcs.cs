using System.ComponentModel.DataAnnotations;

namespace DevaxiloS.Services.DomainModels.Customer
{
    public class EmailValidationRequest : BaseWebRequest
    {
        [Required(ErrorMessage = "Please enter valid email address", AllowEmptyStrings = false)]
        [EmailAddress(ErrorMessage = "Plase enter valid email address")]
        public string Email { get; set; }
    }
    
}
