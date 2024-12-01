using AutoMapper;
using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Core.IRepositories;
using UzmanEgitimDanismanim.Core.IServices;
using UzmanEgitimDanismanim.Core.IUnitOfWorks;
using UzmanEgitimDanismanim.Shared.Dtos;

namespace UzmanEgitimDanismanim.Service.Services
{
    public class SinavDersKonuService : Service<SinavDersKonu, SinavDersKonuDto>, ISinavDersKonuService
    {

        public SinavDersKonuService(IUnitOfWork unitOfWork, IRepository<SinavDersKonu> sinavDersKonuRepository, IMapper mapper) : base(unitOfWork, sinavDersKonuRepository, mapper)
        {
        }
    }
}