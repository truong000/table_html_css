using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Website_demomvc.Models.Account
{
    public class RegisterViewModel
    {
        [Key]

        [DisplayName("Họ và tên")]
        [Required(ErrorMessage = "This field is required.")]
        [MaxLength(30, ErrorMessage = "Maximum 30 characters only.")]
        public string FullName { get; set; }

        [DisplayName("Tuổi")]
        public int Age { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "This field is required.")]
        [MinLength(5, ErrorMessage = "You must input password.")]
        public string Password { get; set; }

    }
}
