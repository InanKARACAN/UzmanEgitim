using UzmanEgitimDanismanim.Shared.Common;

namespace UzmanEgitimDanismanim.Shared.ViewModels
{
    public class OgrenciListeleAraViewModel
    {
        public OgrenciListeleAraViewModel()
        {
            request = new PagerRequest();
        }
        public int DanismanID { get; set; }
        public int KurumID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public PagerRequest request { get; set; }
    }
}