using AutoMapper;
using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Core.IRepositories;
using UzmanEgitimDanismanim.Core.IServices;
using UzmanEgitimDanismanim.Core.IUnitOfWorks;
using UzmanEgitimDanismanim.Shared.Dtos;

namespace UzmanEgitimDanismanim.Service.Services
{
    public class KurumService : Service<Kurum, KurumDto>, IKurumService
    {

        public KurumService(IUnitOfWork unitOfWork, IRepository<Kurum> kurumRepository, IMapper mapper) : base(unitOfWork, kurumRepository, mapper)
        {
        }
    }
}