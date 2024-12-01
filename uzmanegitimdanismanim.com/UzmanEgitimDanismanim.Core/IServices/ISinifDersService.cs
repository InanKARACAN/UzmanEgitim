using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Shared.Dtos;

namespace UzmanEgitimDanismanim.Core.IServices
{
    public interface ISinifDersService : IService<SinifDers, SinifDersDto>
    {
        Task<List<SinifDersDto>> SinifDersleriGetir(int sinifId);
    }
}