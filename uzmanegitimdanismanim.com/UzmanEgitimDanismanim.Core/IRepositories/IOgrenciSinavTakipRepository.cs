using UzmanEgitimDanismanim.Core.Entities;

namespace UzmanEgitimDanismanim.Core.IRepositories
{
    public interface IOgrenciSinavTakipRepository : IRepository<OgrenciSinavTakip>
    {
        IQueryable<OgrenciSinavTakip> OgrenciSinavTakipGetir();
    }
}
