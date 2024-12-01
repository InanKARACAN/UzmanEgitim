using AutoMapper;
using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Core.IRepositories;
using UzmanEgitimDanismanim.Core.IServices;
using UzmanEgitimDanismanim.Core.IUnitOfWorks;
using UzmanEgitimDanismanim.Shared.Dtos;

namespace UzmanEgitimDanismanim.Service.Services
{
    public class SinavService : Service<Sinav, SinavDto>, ISinavService
    {

        public SinavService(IUnitOfWork unitOfWork, IRepository<Sinav> sinavRepository, IMapper mapper) : base(unitOfWork, sinavRepository, mapper)
        {
        }
    }
}