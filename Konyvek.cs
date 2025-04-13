using System.ComponentModel.DataAnnotations;

namespace KonyvtarAPI
{
    public class Konyvek
    {
        [Required]
        //(EF által automatikusan generált)
        public int LeltariSzam { get; set; }
        [Required]
        public string Cim { get; set; }
        [Required]
        public string Szerzo { get; set; }
        [Required]
        public string Kiado { get; set; }
        [Required]
        //Validációs kikötés: Az érték nem lehet negatív
        public int KiadasEve { get; set; }
    }
}
