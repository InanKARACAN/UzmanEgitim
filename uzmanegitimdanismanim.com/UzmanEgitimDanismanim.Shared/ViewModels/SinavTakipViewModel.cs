using UzmanEgitimDanismanim.Shared.Common;
using UzmanEgitimDanismanim.Shared.Dtos;
using UzmanEgitimDanismanim.Shared.Responses;

namespace UzmanEgitimDanismanim.Shared.ViewModels
{
    public class SinavTakipViewModel
    {
        public SinavTakipViewModel()
        {
            Model = new PagedModel<OgrenciSinavTakipDto>();
            araViewModel = new SinavTakipAraViewModel();
            PageInfo = new PageInfo();
        }
        public PagedModel<OgrenciSinavTakipDto> Model { get; set; }
        public SinavTakipAraViewModel araViewModel { get; set; }
        public PageInfo PageInfo;
    }
}