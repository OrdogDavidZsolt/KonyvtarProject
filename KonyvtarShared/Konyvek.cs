using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KonyvtarAPI.CustomValidators;

namespace KonyvtarAPI.KonyvtarShared
{
    public class Konyvek
    {
        [Key]
        [Display(Name = "Leltári szám")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeltariSzam { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Könyv címe")]
        public string Cim { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Szerző")]
        public string Szerzo { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Kiadó")]
        public string Kiado { get; set; }

        /*
        Validációs kikötés: Az érték nem lehet negatív
        Validációs kikötés: Az érték nem lehet a jelenlegi napnál későbbi
            https://stackoverflow.com/questions/42449369/how-can-i-used-datetime-today-as-a-paramter-in-dataannotations-rangeattribute
        */
        [Required]
        [Display(Name = "Kiadás éve")]
        [YearBeforeCurrentYear]
        public int KiadasEve { get; set; }
    }
}
