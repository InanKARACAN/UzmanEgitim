using UzmanEgitimDanismanim.Core.Entities;
using UzmanEgitimDanismanim.Core.IRepositories;

namespace UzmanEgitimDanismanim.Data.Repositories
{
    public class OgrenciSinavTakipCozumRepository : Repository<OgrenciSinavTakipCozum>, IOgrenciSinavTakipCozumRepository
    {
        public OgrenciSinavTakipCozumRepository(SqlDbContext context) : base(context)
        {
        }
    }
}