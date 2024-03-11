using System.ComponentModel.DataAnnotations;

namespace MVC_Krivec.Models
{
    public class Bend
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Vnos je obvezen")]
        public string naziv { get; set; }
        [Required(ErrorMessage = "Vnos je obvezen")]
        public string drzava { get; set; }
        [Required(ErrorMessage = "Vnos je obvezen")]
        public int LetoUstanovitve { get; set; }
        [Required(ErrorMessage = "Vnos je obvezen")]
        public int TurnejaTK { get; set; }

        public Bend(string naziv, string drzava, int letoUstanovitve, int turnejaTK)
        {
            this.naziv = naziv;
            this.drzava = drzava;
            this.LetoUstanovitve = letoUstanovitve;
            this.TurnejaTK= turnejaTK;

        }
        public Bend() { }
    }
}
