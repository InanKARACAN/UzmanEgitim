using UzmanEgitimDanismanim.Core.Entities;

namespace UzmanEgitimDanismanim.Core.IRepositories
{
    public interface IOgrenciSoruTakipRepository : IRepository<OgrenciSoruTakip>
    {
        IQueryable<OgrenciSoruTakip> OgrenciSoruTakipGetir();
        Task<List<OgrenciSoruTakip>> OgrenciSoruGrafikGetir(int ogrenciId, int sinifId, DateTime? baslangicTarihi, DateTime? bitisTarihi);
        Task<List<OgrenciSoruTakip>> OgrenciSoruKonuGrafikGetir(int ogrenciId, int sinifId, DateTime? baslangicTarihi, DateTime? bitisTarihi, string dersAdi);
    }
}