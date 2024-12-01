using AutoMapper;
using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Core.IRepositories;
using UzmanEgitimDanismanim.Core.IServices;
using UzmanEgitimDanismanim.Core.IUnitOfWorks;
using UzmanEgitimDanismanim.Shared.Dtos;

namespace UzmanEgitimDanismanim.Service.Services
{
    public class OgrenciKendiniDegerlendirmeService : Service<OgrenciKendiniDegerlendirme,OgrenciKendiniDegerlendirmeDto>, IOgrenciKendiniDegerlendirmeService
    {

        public OgrenciKendiniDegerlendirmeService(IUnitOfWork unitOfWork, IRepository<OgrenciKendiniDegerlendirme> ogrenciKendiniDegerlendirmeRepository, IMapper mapper) : base(unitOfWork, ogrenciKendiniDegerlendirmeRepository, mapper)
        {
        }

        //public async Task<List<OgrenciDersTakipDto>> OgrenciDersTakipGetir(int ogrenciId, int sinifId)
        //{
        //    var sonuc = await _unitOfWork.OgrenciDersTakipler.OgrenciDersTakipGetir(ogrenciId, sinifId);
        //    return _mapper.Map<List<OgrenciDersTakipDto>>(sonuc);
        //}
    }
}