using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Shared.Dtos;

namespace UzmanEgitimDanismanim.Core.IServices
{
    public interface IVeliOgrenciService : IService<VeliOgrenci, VeliOgrenciDto>
    {
        Task<List<VeliOgrenciDto>> VeliOgrencileriGetir(int veliId);
    }
}