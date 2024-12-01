using AutoMapper;
using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Core.IRepositories;
using UzmanEgitimDanismanim.Core.IServices;
using UzmanEgitimDanismanim.Core.IUnitOfWorks;
using UzmanEgitimDanismanim.Shared.Dtos;

namespace UzmanEgitimDanismanim.Service.Services
{
    public class SinavDersService : Service<SinavDers, SinavDersDto>, ISinavDersService
    {

        public SinavDersService(IUnitOfWork unitOfWork, IRepository<SinavDers> sinavDersRepository, IMapper mapper) : base(unitOfWork, sinavDersRepository, mapper)
        {
        }
    }
}