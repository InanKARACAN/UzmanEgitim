using Microsoft.AspNetCore.Mvc;
using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Shared.ViewModels;

namespace UzmanEgitimDanismanim.Core.IRepositories
{
    public interface IOgrenciDersTakipRepository : IRepository<OgrenciDersTakip>
    {
        IQueryable<OgrenciDersTakip> OgrenciDersTakipGetir();
        Task<List<OgrenciDersTakip>> OgrenciDersGrafikGetir(int ogrenciId, int sinifId, DateTime? baslangicTarihi, DateTime? bitisTarihi);
        Task<List<OgrenciDersTakip>> OgrenciDersKonuGrafikGetir(int ogrenciId, int sinifId, DateTime? baslangicTarihi, DateTime? bitisTarihi, string dersAdi);
    }
}