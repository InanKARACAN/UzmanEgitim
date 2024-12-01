using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UzmanEgitimDanismanim.Shared.Enums
{
    public enum OgrenciDokumanKategoriEnum : byte
    {
        [Display(Name = "Danışman Raporu")]
        [Description("Danışman Raporu")]
        DanismanRaporu = 1,

        [Display(Name = "Dökümanlar")]
        [Description("Dökümanlar")]
        Dokumanlar = 2,

        [Display(Name = "Kaynak Önerisi")]
        [Description("Kaynak Önerisi")]
        KaynakOnerisi = 3,

        [Display(Name = "CV")]
        [Description("Cv")]
        Cv = 4,
    }
}