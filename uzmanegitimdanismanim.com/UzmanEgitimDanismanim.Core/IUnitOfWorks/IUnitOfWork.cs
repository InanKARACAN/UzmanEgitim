using UzmanEgitimDanismanim.Core.IRepositories;

namespace UzmanEgitimDanismanim.Core.IUnitOfWorks
{
    public interface IUnitOfWork
    {
        IKullaniciRolRepository KullaniciRoller { get; }
        IKullaniciRepository Kullanicilar { get; }
        IKurumRepository Kurumlar { get; }
        IOgrenciDokumanRepository OgrenciDokumanlar { get; }
        IOgrenciDersTakipRepository OgrenciDersTakipler { get; }
        IOgrenciSoruTakipRepository OgrenciSoruTakipler { get; }
        IOgrenciSinavTakipRepository OgrenciSinavTakipler { get; }
        IOgrenciSinavTakipCozumRepository OgrenciSinavTakipCozumler { get; }
        IOgrenciGorevTakipRepository OgrenciGorevTakipler { get; }
        IOgrenciSinifRepository OgrenciSiniflar { get; }
        ISinavDersKonuRepository SinavDersKonular { get; }
        ISinavDersRepository SinavDersler { get; }
        ISinavRepository Sinavlar { get; }
        ISinifDersKonuRepository SinifDersKonular { get; }
        ISinifDersRepository SinifDersler { get; }
        ISinifRepository Siniflar { get; }
        IVeliOgrenciRepository VeliOgrenciler { get; }
        IOgrenciEnvanteriHollandRepository OgrenciEnvanteriHollandlar { get; }
        IDanismanOgrenciRepository DanismanOgrenciler { get; }

        Task CommitAsync();
        void Commit();
    }
}
