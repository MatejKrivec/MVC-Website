using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Krivec.Models
{
    public class Uporabnik_z_Gesli : RegisterModel
    {
        public string Role { get; set; }

      //  [NotMapped]
        [Required(ErrorMessage = "Vnos je obvezen")]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{8,}$", ErrorMessage = "The password must contain at least one number and at least one special character.")]
        public string Geslo { get; set; }

     //   [NotMapped]
        [Required(ErrorMessage = "Vnos je obvezen")]
        [Compare("Geslo", ErrorMessage = "The passwords do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
