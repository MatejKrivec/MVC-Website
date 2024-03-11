using System.ComponentModel.DataAnnotations;

namespace MVC_Krivec.Models
{
    public class NarocanjeMercha
    {
        [Key]
        public int Id { get; set; }

        public string naziv { get; set; }

        public int cena { get; set; }


        public string kraj { get; set; }

        public int posta { get; set; }

        public string naslov { get; set; }

        public DateTime DatumInCas { get; set; }

        public int TK_User { get; set; }
    }
}
