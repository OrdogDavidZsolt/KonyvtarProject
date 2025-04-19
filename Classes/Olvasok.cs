using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KonyvtarAPI.CustomValidators;

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

        //Validációs kikötés: Születési dátum nem lehet kisebb mint 1900
        [Required]
        [ValidBetweenTodayAnd("1900-01-01")]
        public DateOnly SzuletesiDatum { get; set; }
    }
}
