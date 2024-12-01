using AutoMapper;
using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Core.IRepositories;
using UzmanEgitimDanismanim.Core.IServices;
using UzmanEgitimDanismanim.Core.IUnitOfWorks;
using UzmanEgitimDanismanim.Shared.Dtos;

namespace UzmanEgitimDanismanim.Service.Services
{
    public class OgrenciGorevTakipService : Service<OgrenciGorevTakip, OgrenciGorevTakipDto>, IOgrenciGorevTakipService
    {

        public OgrenciGorevTakipService(IUnitOfWork unitOfWork, IRepository<OgrenciGorevTakip> ogrenciGorevTakipRepository, IMapper mapper) : base(unitOfWork, ogrenciGorevTakipRepository, mapper)
        {
        }

        public async Task<List<OgrenciGorevTakipDto>> OgrenciGorevTakipGetir(int ogrenciId)
        {
            var sonuc = await _unitOfWork.OgrenciGorevTakipler.OgrenciGorevTakipGetir(ogrenciId);
            return _mapper.Map<List<OgrenciGorevTakipDto>>(sonuc);
        }
    }
}