using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UzmanEgitimDanismanim.Shared.Enums
{
    public enum SinavZorlukSeviyesiEnum : byte
    {
        [Display(Name = "-- Seçiniz --")]
        [Description("Seçiniz")]
        Seciniz = 0,

        [Display(Name = "Kolay")]
        [Description("Kolay")]
        Kolay = 1,

        [Display(Name = "Orta")]
        [Description("Orta")]
        Orta = 2,

        [Display(Name = "Zor")]
        [Description("Zor")]
        Zor = 3,
    }
}