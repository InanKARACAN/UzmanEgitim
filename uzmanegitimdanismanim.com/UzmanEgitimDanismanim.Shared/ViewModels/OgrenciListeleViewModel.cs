using UzmanEgitimDanismanim.Shared.Common;
using UzmanEgitimDanismanim.Shared.Dtos;
using UzmanEgitimDanismanim.Shared.Responses;

namespace UzmanEgitimDanismanim.Shared.ViewModels
{
    public class OgrenciListeleViewModel
    {
        public OgrenciListeleViewModel()
        {
            Model = new PagedModel<DanismanOgrenciDto>();
            araViewModel = new OgrenciListeleAraViewModel();
            PageInfo = new PageInfo();
        }
        public PagedModel<DanismanOgrenciDto> Model { get; set; }
        public OgrenciListeleAraViewModel araViewModel { get; set; }
        public PageInfo PageInfo;
    }
}