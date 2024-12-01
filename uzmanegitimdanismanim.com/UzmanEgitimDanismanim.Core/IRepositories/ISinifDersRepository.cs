using UzmanEgitimDanismanim.Core.Entities;

namespace UzmanEgitimDanismanim.Core.IRepositories
{
    public interface ISinifDersRepository : IRepository<SinifDers>
    {
        Task<List<SinifDers>> SinifDersleriGetir(int sinifId);
    }
}
