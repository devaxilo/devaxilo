using System.ComponentModel.DataAnnotations;

namespace DevaxiloS.Services.DomainModels.Customer
{
    public class CustomerRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CustomerLoginRequest
    {
        [Required(ErrorMessage = "Please enter valid email address", AllowEmptyStrings = false)]
        [EmailAddress(ErrorMessage = "Plase enter valid email address")]
        public string Email { get; set; }
    }

    public class CustomerLoginFromEmailRequest : CustomerLoginRequest
    {
        [Required(ErrorMessage = "Wrong code", AllowEmptyStrings = false)]
        public string CLogin { get; set; }
    }
}
