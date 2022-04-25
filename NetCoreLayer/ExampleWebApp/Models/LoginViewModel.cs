using System.ComponentModel.DataAnnotations;

namespace ExampleWebApp.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please fill this area.")]
        [EmailAddress(ErrorMessage = "Please enter a valid e-mail.")]
        public string UserEMail { get; set; }
        [Required(ErrorMessage = "Please enter your passoord.")]
        public string UserPassword { get; set; }
    }
}
