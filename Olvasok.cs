using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace KonyvtarAPI
{
    public class Olvasok
    {
        //(EF által automatikusan generált)
        [Required]
        public int OlvasoSzam { get; set; }

        [Required]
        public string OlvasoNev { get; set; }

        [Required]
        public string Lakcim { get; set; }

        //Validációs kikötés: Az érték nem lehet kisebb mint 1900
        [Required]
        [ValidBetweenTodayAnd("1900-01-01")]
        public DateTime SzuletesiDatum { get; set; }
    }
}
