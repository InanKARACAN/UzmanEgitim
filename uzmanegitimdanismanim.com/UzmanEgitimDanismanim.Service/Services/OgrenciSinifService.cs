using AutoMapper;
using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Core.IRepositories;
using UzmanEgitimDanismanim.Core.IServices;
using UzmanEgitimDanismanim.Core.IUnitOfWorks;
using UzmanEgitimDanismanim.Shared.Dtos;

namespace UzmanEgitimDanismanim.Service.Services
{
    public class OgrenciSinifService : Service<OgrenciSinif, OgrenciSinifDto>, IOgrenciSinifService
    {

        public OgrenciSinifService(IUnitOfWork unitOfWork, IRepository<OgrenciSinif> ogrenciSinifRepository, IMapper mapper) : base(unitOfWork, ogrenciSinifRepository, mapper)
        {
        }

        public async Task<List<OgrenciSinifDto>> OgrenciSiniflariGetir(int ogrenciId)
        {
            var sonuc = await _unitOfWork.OgrenciSiniflar.OgrenciSiniflariGetir(ogrenciId);
            return _mapper.Map<List<OgrenciSinifDto>>(sonuc);
        }
    }
}