using UzmanEgitimDanismanim.Core.Entities;

namespace UzmanEgitimDanismanim.Core.IRepositories
{
    public interface IOgrenciSinifRepository : IRepository<OgrenciSinif>
    {
        Task<List<OgrenciSinif>> OgrenciSiniflariGetir(int ogrenciId);
    }
}