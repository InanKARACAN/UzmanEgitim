using UzmanEgitimDanismanim.Core.IRepositories;
using UzmanEgitimDanismanim.Core.IUnitOfWorks;
using UzmanEgitimDanismanim.Data.Repositories;

namespace UzmanEgitimDanismanim.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlDbContext _context;

        public UnitOfWork(SqlDbContext context)
        {
            _context = context;
        }

        private KullaniciRepository _kullaniciRepository;
        private KullaniciRolRepository _kullaniciRolRepository;
        private KurumRepository _kurumRepository;
        
        private OgrenciDokumanRepository _ogrenciDokumanRepository;
        private OgrenciDersTakipRepository _ogrenciDersTakipRepository;
        private OgrenciSoruTakipRepository _ogrenciSoruTakipRepository;
        private OgrenciSinavTakipRepository _ogrenciSinavTakipRepository;
        private OgrenciSinavTakipCozumRepository _ogrenciSinavTakipCozumRepository;
        private OgrenciGorevTakipRepository _ogrenciGorevTakipRepository;

        private OgrenciSinifRepository _ogrenciSinifRepository;
        private SinavDersKonuRepository _sinavDersKonuRepository;
        private SinavDersRepository _sinavDersRepository;
        private SinavRepository _sinavRepository;
        private SinifDersKonuRepository _sinifDersKonuRepository;
        private SinifDersRepository _sinifDersRepository;
        private SinifRepository _sinifRepository;
        private VeliOgrenciRepository _veliOgrenciRepository;
        private OgrenciEnvanteriHollandRepository _ogrenciEnvanteriHollandRepository;
        private DanismanOgrenciRepository _danismanOgrenciRepository;


        public IKullaniciRepository Kullanicilar => _kullaniciRepository = _kullaniciRepository ?? new KullaniciRepository(_context);
        public IKullaniciRolRepository KullaniciRoller => _kullaniciRolRepository = _kullaniciRolRepository ?? new KullaniciRolRepository(_context);
        public IKurumRepository Kurumlar => _kurumRepository = _kurumRepository ?? new KurumRepository(_context);
        
        
        public IOgrenciDokumanRepository OgrenciDokumanlar => _ogrenciDokumanRepository = _ogrenciDokumanRepository ?? new OgrenciDokumanRepository(_context);
        public IOgrenciDersTakipRepository OgrenciDersTakipler => _ogrenciDersTakipRepository = _ogrenciDersTakipRepository ?? new OgrenciDersTakipRepository(_context);
        public IOgrenciSoruTakipRepository OgrenciSoruTakipler => _ogrenciSoruTakipRepository = _ogrenciSoruTakipRepository ?? new OgrenciSoruTakipRepository(_context);
        public IOgrenciSinavTakipRepository OgrenciSinavTakipler => _ogrenciSinavTakipRepository = _ogrenciSinavTakipRepository ?? new OgrenciSinavTakipRepository(_context);
        public IOgrenciSinavTakipCozumRepository OgrenciSinavTakipCozumler => _ogrenciSinavTakipCozumRepository = _ogrenciSinavTakipCozumRepository ?? new OgrenciSinavTakipCozumRepository(_context);
        public IOgrenciGorevTakipRepository OgrenciGorevTakipler => _ogrenciGorevTakipRepository = _ogrenciGorevTakipRepository ?? new OgrenciGorevTakipRepository(_context);
        public IOgrenciSinifRepository OgrenciSiniflar => _ogrenciSinifRepository = _ogrenciSinifRepository ?? new OgrenciSinifRepository(_context);
        public ISinavDersKonuRepository SinavDersKonular => _sinavDersKonuRepository = _sinavDersKonuRepository ?? new SinavDersKonuRepository(_context);
        public ISinavDersRepository SinavDersler => _sinavDersRepository = _sinavDersRepository ?? new SinavDersRepository(_context);
        public ISinavRepository Sinavlar => _sinavRepository = _sinavRepository ?? new SinavRepository(_context);
        public ISinifDersKonuRepository SinifDersKonular => _sinifDersKonuRepository = _sinifDersKonuRepository ?? new SinifDersKonuRepository(_context);
        public ISinifDersRepository SinifDersler => _sinifDersRepository = _sinifDersRepository ?? new SinifDersRepository(_context);
        public ISinifRepository Siniflar => _sinifRepository = _sinifRepository ?? new SinifRepository(_context);
        public IVeliOgrenciRepository VeliOgrenciler => _veliOgrenciRepository = _veliOgrenciRepository ?? new VeliOgrenciRepository(_context);
        public IOgrenciEnvanteriHollandRepository OgrenciEnvanteriHollandlar => _ogrenciEnvanteriHollandRepository = _ogrenciEnvanteriHollandRepository ?? new OgrenciEnvanteriHollandRepository(_context);
        public IDanismanOgrenciRepository DanismanOgrenciler => _danismanOgrenciRepository = _danismanOgrenciRepository ?? new DanismanOgrenciRepository(_context);


        public void Commit()
        {
            _context.SaveChanges();
        }
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}