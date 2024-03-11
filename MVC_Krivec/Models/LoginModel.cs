using System.ComponentModel.DataAnnotations;

namespace MVC_Krivec.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Vnos je obvezen")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vnos je obvezen")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
