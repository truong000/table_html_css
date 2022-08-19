using System.ComponentModel.DataAnnotations;

namespace Website_demomvc.Models.Account
{
    public class LoginViewModel
    {
        [Key]

        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [MinLength(5, ErrorMessage = "You must input password.")]
        public string Password { get; set; }
    }
}
