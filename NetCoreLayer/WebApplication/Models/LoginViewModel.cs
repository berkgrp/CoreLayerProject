using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please fill this area.")]
        [EmailAddress(ErrorMessage ="Please enter a valid e-mail.")]
        public string UserEMail { get; set; }
        [Required(ErrorMessage = "Please fill this area.")]
        public string UserPassword { get; set; }

    }
}
