using System.ComponentModel.DataAnnotations;

namespace MVC_Krivec.Models
{
    public class RegisterModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Vnos je obvezen")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please enter only letters.")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Vnos je obvezen")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please enter only letters.")]
        public string Priimek { get; set; }

        [Required(ErrorMessage = "Vnos je obvezen")]
        [Display(Name = "Rojstni dan")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime RojstniDan { get; set; }


        [Required(ErrorMessage = "Vnos je obvezen")]
        [RegularExpression(@"^\d{13}$", ErrorMessage = "The number must be exactly 13 digits.")]
        public string EMSO { get; set; }

        [Required(ErrorMessage = "Vnos je obvezen")]
        public int starost { get; set; }

        [Required(ErrorMessage = "Vnos je obvezen")]
        public string KrajRojstva { get; set; }


        [Required(ErrorMessage = "Vnos je obvezen")]
        public string naslov { get; set; }

        [Required(ErrorMessage = "Vnos je obvezen")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double PostnaST { get; set; }

        [Required(ErrorMessage = "Vnos je obvezen")]
        public string Posta { get; set; }

        [Required(ErrorMessage = "Vnos je obvezen")]
        public string Drzava { get; set; }



        [Required(ErrorMessage = "Vnos je obvezen")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }


      /*
        [Required(ErrorMessage = "Vnos je obvezen")]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{8,}$", ErrorMessage = "The password must contain at least one number and at least one special character.")]
        public string Geslo { get; set; }

        [Required(ErrorMessage = "Vnos je obvezen")]
        [Compare("Geslo", ErrorMessage = "The passwords do not match.")]
        public string ConfirmPassword { get; set; }
      */

    }
}
