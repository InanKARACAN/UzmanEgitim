using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Shared.Dtos;

namespace UzmanEgitimDanismanim.Core.IServices
{
    public interface IOgrenciGorevTakipService : IService<OgrenciGorevTakip, OgrenciGorevTakipDto>
    {
        Task<List<OgrenciGorevTakipDto>> OgrenciGorevTakipGetir(int ogrenciId);
    }
}