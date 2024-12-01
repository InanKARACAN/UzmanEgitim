using UzmanEgitimDanismanim.Shared.Enums;

namespace UzmanEgitimDanismanim.Shared.Dtos
{
    public class OgrenciSinavTakipDto : BaseDto, IDto
    {
        public int OgrenciId { get; set; }
        public int SinavId { get; set; }
        public SinavDto Sinav { get; set; }
        public string SinavAdi { get; set; }
        public SinavZorlukSeviyesiEnum ZorlukSeviyesi { get; set; }
        public DateTime CozumTarihi { get; set; }
        public List<OgrenciSinavTakipCozumDto> OgrenciSinavTakipCozumler { get; set; }
    }
}