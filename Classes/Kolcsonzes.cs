using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KonyvtarAPI.CustomValidators;

namespace KonyvtarAPI
{
    public class Kolcsonzes
    {
        [Key]
        [Display(Name = "Kölcsönzés azonosító")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KolcsonzesSzam { get; set; }

        //Olvasók kapcsolat
        [Display(Name = "Olvasó szám")]
        [ForeignKey("OlvasoSzam")]
        public int OlvasoSzam { get; set; }

        //Könyvek kapcsolat
        [Display(Name = "Leltári szám")]
        [ForeignKey("LeltariSzam")]
        public int LeltariSzam { get; set; }

        //Validációs kikötés: Az érték nem lehet a jelenlegi napnál későbbi (A feladat korábbi-t írt, de szerintem ennek így van értelme)
        [Required]
        [Display(Name = "Kölcsönzés ideje")]
        [NotLaterThanToday]
        public DateOnly KolcsonzesIdeje { get; set; }

        //Validációs kikötés: A visszahozás ideje később legyen mint a kölcsönzés ideje
        [Required]
        [Display(Name = "Visszahozás határideje")]
        [NotEarlierThan("KolcsonzesIdeje")]
        public DateOnly VisszahozasHatarido { get; set; }
    }
}
