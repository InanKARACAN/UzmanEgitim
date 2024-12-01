using UzmanEgitimDanismanim.Core.Entities;

namespace UzmanEgitimDanismanim.Core.IRepositories
{
    public interface ISinifDersKonuRepository : IRepository<SinifDersKonu>
    {
        Task<List<SinifDersKonu>> SinifDersKonulariGetir(int sinifDersId);
    }
}
