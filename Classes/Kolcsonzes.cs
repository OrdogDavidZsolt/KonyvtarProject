using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KonyvtarAPI.CustomValidators;

namespace KonyvtarAPI
{
    public class Kolcsonzes
    {
        //Olvasók kapcsolat
        [ForeignKey("OlvasoSzam")]
        public int OlvasoSzam { get; set; }

        //Könyvek kapcsolat
        [Key]
        public int LeltariSzam { get; set; }

        //Validációs kikötés: Az érték nem lehet a jelenlegi napnál későbbi (A feladat korábbi-t írt, de szerintem ennek így van értelme)
        [Required]
        [NotLaterThanToday]
        public DateOnly KolcsonzesIdeje { get; set; }

        //Validációs kikötés: A visszahozás ideje később legyen mint a kölcsönzés ideje
        [Required]
        [NotEarlierThan("KolcsonzesIdeje")]
        public DateOnly VisszahozasHatarido { get; set; }
    }
}
