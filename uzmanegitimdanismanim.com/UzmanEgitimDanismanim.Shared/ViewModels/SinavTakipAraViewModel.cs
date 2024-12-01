using System.ComponentModel;
using UzmanEgitimDanismanim.Shared.Common;

namespace UzmanEgitimDanismanim.Shared.ViewModels
{
    public class SinavTakipAraViewModel
    {
        public SinavTakipAraViewModel()
        {
            request = new PagerRequest();
        }
        public int OgrenciId { get; set; }
        public int SinifId { get; set; }
        [DisplayName("Başlangıç Tarihi")]
        public DateTime? BaslangicTarihi { get; set; }
        [DisplayName("Bitiş Tarihi")]
        public DateTime? BitisTarihi { get; set; }
        public PagerRequest request { get; set; }
    }
}