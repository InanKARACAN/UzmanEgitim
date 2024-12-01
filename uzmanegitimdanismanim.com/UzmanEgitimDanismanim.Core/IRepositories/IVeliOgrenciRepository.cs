using UzmanEgitimDanismanim.Core.Entities;

namespace UzmanEgitimDanismanim.Core.IRepositories
{
    public interface IVeliOgrenciRepository : IRepository<VeliOgrenci>
    {
        Task<List<VeliOgrenci>> VeliOgrencileriGetir(int veliId);
    }
}
