using AutoMapper;
using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Core.IRepositories;
using UzmanEgitimDanismanim.Core.IServices;
using UzmanEgitimDanismanim.Core.IUnitOfWorks;
using UzmanEgitimDanismanim.Shared.Dtos;

namespace UzmanEgitimDanismanim.Service.Services
{
    public class OgrenciSinavTakipCozumService : Service<OgrenciSinavTakipCozum, OgrenciSinavTakipCozumDto>, IOgrenciSinavTakipCozumService
    {

        public OgrenciSinavTakipCozumService(IUnitOfWork unitOfWork, IRepository<OgrenciSinavTakipCozum> ogrenciSinavTakipCozumRepository, IMapper mapper) : base(unitOfWork, ogrenciSinavTakipCozumRepository, mapper)
        {
        }
    }
}