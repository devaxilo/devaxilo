using System.ComponentModel.DataAnnotations;

namespace DevaxiloS.Services.DomainModels.Customer
{
    public class EmailValidationRequest : BaseWebRequest
    {
        [Required(ErrorMessage = "Please enter valid email address", AllowEmptyStrings = false)]
        [EmailAddress(ErrorMessage = "Plase enter valid email address")]
        public string Email { get; set; }
    }

    public class UserValidationRequest : EmailValidationRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Wrong code")]
        public string Skey { get; set; }
    }
}
