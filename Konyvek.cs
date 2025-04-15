using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KonyvtarAPI
{
    public class Konyvek
    {
        //(EF által automatikusan generált)
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeltariSzam { get; set; }

        [Required]
        public string Cim { get; set; }

        [Required]
        public string Szerzo { get; set; }

        [Required]
        public string Kiado { get; set; }

        /*
        Validációs kikötés: Az érték nem lehet negatív
        Validációs kikötés: Az érték nem lehet a jelenlegi napnál későbbi
            https://stackoverflow.com/questions/42449369/how-can-i-used-datetime-today-as-a-paramter-in-dataannotations-rangeattribute
        */
        [Required]
        [Range(typeof(DateOnly), "0000-01-01", "9999-12-31", ErrorMessage = "A kiadás éve nem lehet negatív.")]
        [ValidBetweenTodayAnd("0001-01-01")]
        public int KiadasEve { get; set; }
    }
}
