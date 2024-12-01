using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Shared.Dtos;

namespace UzmanEgitimDanismanim.Core.IServices
{
    public interface ISinifDersKonuService : IService<SinifDersKonu, SinifDersKonuDto>
    {
        Task<List<SinifDersKonuDto>> SinifDersKonulariGetir(int sinifDersId);
    }
}