using System.ComponentModel.DataAnnotations;

namespace KonyvtarAPI
{
    public class Kolcsonzes
    {
        [Required]
        //Olvasók kapcsolat
        public int OlvasoSzam { get; set; }

        [Required]
        //Könyvek kapcsolat
        public int LeltariSzam { get; set; }

        [Required]
        //Validációs kikötés: Az érték nem lehet a jelenlegi napnál korábbi
        public DateTime KolcsonzesIdeje { get; set; }

        [Required]
        //Validációs kikötés: A visszahozás ideje később legyen mint a kölcsönzés ideje
        public DateTime VisszahozasHatarido { get; set; }
    }
}
