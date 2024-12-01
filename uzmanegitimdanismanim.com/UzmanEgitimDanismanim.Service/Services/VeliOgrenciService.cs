using AutoMapper;
using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Core.IRepositories;
using UzmanEgitimDanismanim.Core.IServices;
using UzmanEgitimDanismanim.Core.IUnitOfWorks;
using UzmanEgitimDanismanim.Shared.Dtos;

namespace UzmanEgitimDanismanim.Service.Services
{
    public class VeliOgrenciService : Service<VeliOgrenci, VeliOgrenciDto>, IVeliOgrenciService
    {

        public VeliOgrenciService(IUnitOfWork unitOfWork, IRepository<VeliOgrenci> veliOgrenciRepository, IMapper mapper) : base(unitOfWork, veliOgrenciRepository, mapper)
        {
        }

        public async Task<List<VeliOgrenciDto>> VeliOgrencileriGetir(int veliId)
        {
            var sonuc = await _unitOfWork.VeliOgrenciler.VeliOgrencileriGetir(veliId);
            return _mapper.Map<List<VeliOgrenciDto>>(sonuc);
        }
    }
}