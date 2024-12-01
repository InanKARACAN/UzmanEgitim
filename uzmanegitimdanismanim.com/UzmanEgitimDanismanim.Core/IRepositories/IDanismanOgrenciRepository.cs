using UzmanEgitimDanismanim.Core.Entities;

namespace UzmanEgitimDanismanim.Core.IRepositories
{
    public interface IDanismanOgrenciRepository : IRepository<DanismanOgrenci>
    {
        IQueryable<DanismanOgrenci> DanismanOgrencileriGetir();
        IQueryable<DanismanOgrenci> OgrenciDanismaniGetir();
    }
}
