using UzmanEgitimDanismanim.Shared.Common;
using UzmanEgitimDanismanim.Shared.Dtos;
using UzmanEgitimDanismanim.Shared.Responses;

namespace UzmanEgitimDanismanim.Shared.ViewModels
{
    public class DersTakipViewModel
    {
        public DersTakipViewModel()
        {
            Model = new PagedModel<OgrenciDersTakipDto>();
            araViewModel = new DersTakipAraViewModel();
            PageInfo = new PageInfo();
        }
        public PagedModel<OgrenciDersTakipDto> Model { get; set; }
        public DersTakipAraViewModel araViewModel { get; set; }
        public PageInfo PageInfo;
    }
}