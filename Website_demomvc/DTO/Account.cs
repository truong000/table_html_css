using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Website_demomvc.DTO
{
    public class Account
    {
        [Key]

        [DisplayName("Fullname")]
        [Required(ErrorMessage = "This field is required.")]
        [MaxLength(30, ErrorMessage = "Maximum 30 characters only.")]
        [Column(TypeName = "nvarchar(50)")]
        public string FullName { get; set; }

        [DisplayName("Age")]
        [Column(TypeName = "int")]
        public int Age { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Email")]
        [Column(TypeName = "nvarchar(10)")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "This field is required.")]
        [MinLength(5, ErrorMessage = "You must input password.")]
        public string Password { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime DateCreate { get; set; }
    }
}
