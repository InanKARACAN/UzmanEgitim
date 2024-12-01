using AutoMapper;
using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Core.IRepositories;
using UzmanEgitimDanismanim.Core.IServices;
using UzmanEgitimDanismanim.Core.IUnitOfWorks;
using UzmanEgitimDanismanim.Shared.Dtos;

namespace UzmanEgitimDanismanim.Service.Services
{
    public class OgrenciEnvanteriHollandService : Service<OgrenciEnvanteriHolland,OgrenciEnvanteriHollandDto>, IOgrenciEnvanteriHollandService
    {

        public OgrenciEnvanteriHollandService(IUnitOfWork unitOfWork, IRepository<OgrenciEnvanteriHolland> ogrenciEnvanteriHollandRepository, IMapper mapper) : base(unitOfWork, ogrenciEnvanteriHollandRepository, mapper)
        {
        }

        //public async Task<List<OgrenciDersTakipDto>> OgrenciDersTakipGetir(int ogrenciId, int sinifId)
        //{
        //    var sonuc = await _unitOfWork.OgrenciDersTakipler.OgrenciDersTakipGetir(ogrenciId, sinifId);
        //    return _mapper.Map<List<OgrenciDersTakipDto>>(sonuc);
        //}
    }
}