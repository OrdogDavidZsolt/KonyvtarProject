using System.ComponentModel.DataAnnotations;

namespace KonyvtarAPI
{
    public class Kolcsonzes
    {
        //Olvasók kapcsolat
        //EF által automatikusan generált
        [Required]
        public int OlvasoSzam { get; set; }

        //Könyvek kapcsolat
        //EF által automatikusan generált
        [Required]
        public int LeltariSzam { get; set; }

        //Validációs kikötés: Az érték nem lehet a jelenlegi napnál későbbi (A feladat korábbi-t írt, de szerintem ennek így van értelme)
        [Required]
        public DateTime KolcsonzesIdeje { get; set; }

        //Validációs kikötés: A visszahozás ideje később legyen mint a kölcsönzés ideje
        [Required]
        public DateTime VisszahozasHatarido { get; set; }
    }
}
