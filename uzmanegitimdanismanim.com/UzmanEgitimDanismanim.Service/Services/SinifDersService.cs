using AutoMapper;
using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Core.IRepositories;
using UzmanEgitimDanismanim.Core.IServices;
using UzmanEgitimDanismanim.Core.IUnitOfWorks;
using UzmanEgitimDanismanim.Shared.Dtos;

namespace UzmanEgitimDanismanim.Service.Services
{
    public class SinifDersService : Service<SinifDers, SinifDersDto>, ISinifDersService
    {

        public SinifDersService(IUnitOfWork unitOfWork, IRepository<SinifDers> sinifDersRepository, IMapper mapper) : base(unitOfWork, sinifDersRepository, mapper)
        {
        }

        public async Task<List<SinifDersDto>> SinifDersleriGetir(int sinifId)
        {
            var sonuc = await _unitOfWork.SinifDersler.SinifDersleriGetir(sinifId);
            return _mapper.Map<List<SinifDersDto>>(sonuc);
        }
    }
}