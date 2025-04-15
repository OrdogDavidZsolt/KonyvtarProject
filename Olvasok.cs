using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace KonyvtarAPI
{
    public class Olvasok
    {
        //(EF által automatikusan generált)
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
