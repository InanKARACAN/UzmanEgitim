using AutoMapper;
using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Core.IRepositories;
using UzmanEgitimDanismanim.Core.IServices;
using UzmanEgitimDanismanim.Core.IUnitOfWorks;
using UzmanEgitimDanismanim.Shared.Dtos;

namespace UzmanEgitimDanismanim.Service.Services
{
    public class KullaniciRolService : Service<KullaniciRol, KullaniciRolDto>, IKullaniciRolService
    {

        public KullaniciRolService(IUnitOfWork unitOfWork, IRepository<KullaniciRol> kullaniciRolRepository, IMapper mapper) : base(unitOfWork, kullaniciRolRepository, mapper)
        {
        }
    }
}