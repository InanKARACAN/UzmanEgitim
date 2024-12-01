using AutoMapper;
using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Core.IRepositories;
using UzmanEgitimDanismanim.Core.IServices;
using UzmanEgitimDanismanim.Core.IUnitOfWorks;
using UzmanEgitimDanismanim.Shared.Dtos;

namespace UzmanEgitimDanismanim.Service.Services
{
    public class OgrenciDokumanService : Service<OgrenciDokuman, OgrenciDokumanDto>, IOgrenciDokumanService
    {

        public OgrenciDokumanService(IUnitOfWork unitOfWork, IRepository<OgrenciDokuman> ogrenciDokumanRepository, IMapper mapper) : base(unitOfWork, ogrenciDokumanRepository, mapper)
        {
        }

        public List<OgrenciDokumanDto> OgrenciDokumanGetir(int ogrenciID)
        {
            var sonuc = _unitOfWork.OgrenciDokumanlar.OgrenciDokumanGetir()
                .Where(w=> w.OgrenciId == ogrenciID)
                .ToList();
            return _mapper.Map<List<OgrenciDokumanDto>>(sonuc);
        }
    }
}