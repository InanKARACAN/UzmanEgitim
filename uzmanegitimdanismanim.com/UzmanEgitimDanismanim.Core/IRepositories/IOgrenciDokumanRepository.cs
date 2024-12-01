using Microsoft.AspNetCore.Mvc;
using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Shared.ViewModels;

namespace UzmanEgitimDanismanim.Core.IRepositories
{
    public interface IOgrenciDokumanRepository : IRepository<OgrenciDokuman>
    {
        IQueryable<OgrenciDokuman> OgrenciDokumanGetir();
        //Task<List<OgrenciDersTakip>> OgrenciDersGrafikGetir(int ogrenciId, int sinifId, DateTime? baslangicTarihi, DateTime? bitisTarihi);
    }
}