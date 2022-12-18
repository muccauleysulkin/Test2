using System.ComponentModel.DataAnnotations;

namespace Test2.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Email Address")]
        [Required (ErrorMessage = "Need an email to see this big EZ")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
