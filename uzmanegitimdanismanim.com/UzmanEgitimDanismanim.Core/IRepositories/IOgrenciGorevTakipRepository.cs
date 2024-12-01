using UzmanEgitimDanismanim.Core.Entities;

namespace UzmanEgitimDanismanim.Core.IRepositories
{
    public interface IOgrenciGorevTakipRepository : IRepository<OgrenciGorevTakip>
    {
        Task<List<OgrenciGorevTakip>> OgrenciGorevTakipGetir(int ogrenciId);
    }
}
