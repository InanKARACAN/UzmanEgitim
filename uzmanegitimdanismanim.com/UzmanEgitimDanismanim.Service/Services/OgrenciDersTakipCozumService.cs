using AutoMapper;
using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Core.IRepositories;
using UzmanEgitimDanismanim.Core.IServices;
using UzmanEgitimDanismanim.Core.IUnitOfWorks;
using UzmanEgitimDanismanim.Shared.Dtos;

namespace UzmanEgitimDanismanim.Service.Services
{
    public class OgrenciDersTakipCozumService : Service<OgrenciDersTakipCozum, OgrenciDersTakipCozumDto>, IOgrenciDersTakipCozumService
    {

        public OgrenciDersTakipCozumService(IUnitOfWork unitOfWork, IRepository<OgrenciDersTakipCozum> ogrenciDersTakipCozumRepository, IMapper mapper) : base(unitOfWork, ogrenciDersTakipCozumRepository, mapper)
        {
        }
    }
}