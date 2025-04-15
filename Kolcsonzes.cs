using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public DateTime KolcsonzesIdeje { get; set; }

        //Validációs kikötés: A visszahozás ideje később legyen mint a kölcsönzés ideje
        [Required]
        public DateTime VisszahozasHatarido { get; set; }
    }
}
