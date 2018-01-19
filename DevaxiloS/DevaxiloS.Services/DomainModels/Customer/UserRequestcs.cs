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

        public bool Remember { get; set; }
    }

    public class UserInfoRequest : BaseWebRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Hãy điền họ và tên của bạn."), MaxLength(40)]
        public string FullName { get; set; }

        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Hãy điền số điện thoại của bạn."), MaxLength(12)]
        [RegularExpression(@"^([0]{1}[0-9]{9,10})$", ErrorMessage = "Not a valid Phone number")]
        public string Phone { get; set; }
    }
}
