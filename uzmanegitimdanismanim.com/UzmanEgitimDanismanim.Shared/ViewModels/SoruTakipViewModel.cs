using UzmanEgitimDanismanim.Shared.Common;
using UzmanEgitimDanismanim.Shared.Dtos;
using UzmanEgitimDanismanim.Shared.Responses;

namespace UzmanEgitimDanismanim.Shared.ViewModels
{
    public class SoruTakipViewModel
    {
        public SoruTakipViewModel()
        {
            Model = new PagedModel<OgrenciSoruTakipDto>();
            araViewModel = new SoruTakipAraViewModel();
            PageInfo = new PageInfo();
        }
        public PagedModel<OgrenciSoruTakipDto> Model { get; set; }
        public SoruTakipAraViewModel araViewModel { get; set; }
        public PageInfo PageInfo;
    }
}