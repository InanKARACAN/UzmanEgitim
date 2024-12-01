using AutoMapper;
using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Core.IRepositories;
using UzmanEgitimDanismanim.Core.IServices;
using UzmanEgitimDanismanim.Core.IUnitOfWorks;
using UzmanEgitimDanismanim.Shared.Dtos;

namespace UzmanEgitimDanismanim.Service.Services
{
    public class SinifDersKonuService : Service<SinifDersKonu, SinifDersKonuDto>, ISinifDersKonuService
    {

        public SinifDersKonuService(IUnitOfWork unitOfWork, IRepository<SinifDersKonu> sinifDersKonuRepository, IMapper mapper) : base(unitOfWork, sinifDersKonuRepository, mapper)
        {
        }

        public async Task<List<SinifDersKonuDto>> SinifDersKonulariGetir(int sinifDersId)
        {
            var sonuc = await _unitOfWork.SinifDersKonular.SinifDersKonulariGetir(sinifDersId);
            return _mapper.Map<List<SinifDersKonuDto>>(sonuc);
        }
    }
}