using System.ComponentModel.DataAnnotations;

namespace MVC_Krivec.Models
{
    public class Turneje
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string turneja { get; set; }
        [Required]
        public string clani { get; set; }
        [Required]
        public string bendi { get; set; }

        public Turneje(string turneja, string clani, string bend)
        {
            this.turneja = turneja;
            this.clani = clani;
            this.bendi = bend;
        }
        public Turneje() { }
    }
}
