using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KonyvtarAPI.CustomValidators;

namespace KonyvtarAPI.KonyvtarShared
{
    public class Olvasok
    {
        [Key]
        [Display(Name = "Olvasó szám")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OlvasoSzam { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Olvasó név")]
        public string OlvasoNev { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Lakcím")]
        public string Lakcim { get; set; }

        //Validációs kikötés: Születési dátum nem lehet kisebb mint 1900
        [Required]
        [Display(Name = "Születési dátum")]
        [ValidBetweenTodayAnd("1900-01-01")]
        public DateOnly SzuletesiDatum { get; set; }
    }
}
