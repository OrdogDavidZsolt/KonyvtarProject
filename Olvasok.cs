using System.ComponentModel.DataAnnotations;

namespace KonyvtarAPI
{
    public class Olvasok
    {
        [Required]
        //(EF által automatikusan generált)
        public int OlvasoSzam { get; set; }

        [Required]
        public string OlvasoNev { get; set; }

        [Required]
        public string Lakcim { get; set; }

        [Required]
        //Validációs kikötés: Az érték nem lehet kisebb mint 1900
        public DateTime SzuletesiDatum { get; set; }
    }
}
