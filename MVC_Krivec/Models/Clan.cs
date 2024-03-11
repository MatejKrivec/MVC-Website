using System.ComponentModel.DataAnnotations;

namespace MVC_Krivec.Models
{
    public class Clan
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ime { get; set; }
        [Required]
        public string priimek { get; set; }
        [Required]
       // [RegularExpression(@"^(?:\d{1,2}|1[01]\d|120)$", ErrorMessage = "Please enter a number between 1 and 120.")]
        public int starost { get; set; }
        [Required(ErrorMessage = "Vnos je obvezen")]
        public int TurnejaTK { get; set; }

        public Clan(string ime , string priimek, int starost,int turnejaTK) 
        { 
            this.ime = ime;
            this.priimek = priimek;
            this.starost = starost;
            this.TurnejaTK = turnejaTK;
        }
        public Clan() { }

    }
}
