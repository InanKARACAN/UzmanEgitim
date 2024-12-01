using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UzmanEgitimDanismanim.Shared.Enums
{
    public enum GorevTakipDurumEnum : byte
    {
        [Display(Name = "Yeni")]
        [Description("Yeni")]
        Yeni = 0,

        [Display(Name = "Tamamlandı")]
        [Description("Tamamlandı")]
        Tamamlandi = 1,

        [Display(Name = "Tamamlanmadı")]
        [Description("Tamamlanmadı")]
        Tamamlanmadi = 2
    }
}