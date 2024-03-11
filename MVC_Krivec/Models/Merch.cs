using System.ComponentModel.DataAnnotations;

namespace MVC_Krivec.Models
{
    public class Merch
    {
        [Key]
        public int Id { get; set; }

        public string naziv { get; set; }

        public int cena { get; set; }


    }
}
