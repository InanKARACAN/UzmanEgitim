using AutoMapper;
using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Core.IRepositories;
using UzmanEgitimDanismanim.Core.IServices;
using UzmanEgitimDanismanim.Core.IUnitOfWorks;
using UzmanEgitimDanismanim.Shared.Dtos;

namespace UzmanEgitimDanismanim.Service.Services
{
    public class SinifService : Service<Sinif, SinifDto>, ISinifService
    {

        public SinifService(IUnitOfWork unitOfWork, IRepository<Sinif> sinifRepository, IMapper mapper) : base(unitOfWork, sinifRepository, mapper)
        {
        }
    }
}