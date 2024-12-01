using Microsoft.EntityFrameworkCore;
using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Core.IRepositories;

namespace UzmanEgitimDanismanim.Data.Repositories
{
    public class OgrenciGorevTakipRepository : Repository<OgrenciGorevTakip>, IOgrenciGorevTakipRepository
    {
        public OgrenciGorevTakipRepository(SqlDbContext context) : base(context)
        {
        }

        public async Task<List<OgrenciGorevTakip>> OgrenciGorevTakipGetir(int ogrenciId)
        {
            var sonuc = await _context.OgrenciGorevTakipler
                .Where(x => x.OgrenciId == ogrenciId && x.Silindi==false && x.Aktif==true)
                .OrderBy(o => o.GorevBaslangic)
                .ToListAsync();
            return sonuc;
        }
    }
}