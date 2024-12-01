using UzmanEgitimDanismanim.Core.IRepositories;
using UzmanEgitimDanismanim.Core.IServices;
using UzmanEgitimDanismanim.Core.IUnitOfWorks;
using UzmanEgitimDanismanim.Data.Repositories;
using UzmanEgitimDanismanim.Data.UnitOfWorks;
using UzmanEgitimDanismanim.Service.Services;

namespace UzmanEgitimDanismanim.Web
{
    public static class DependencyInjection
    {
        public static void AddDi(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<,>), typeof(Service<,>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IKullaniciRolService, KullaniciRolService>();
            services.AddScoped<IKullaniciService, KullaniciService>();
            services.AddScoped<IKurumService, KurumService>();
            services.AddScoped<IOgrenciDokumanService, OgrenciDokumanService>();
            services.AddScoped<IOgrenciDersTakipService, OgrenciDersTakipService>();
            services.AddScoped<IOgrenciSoruTakipService, OgrenciSoruTakipService>();
            services.AddScoped<IOgrenciSinavTakipService, OgrenciSinavTakipService>();
            services.AddScoped<IOgrenciGorevTakipService, OgrenciGorevTakipService>();
            services.AddScoped<IOgrenciSinifService, OgrenciSinifService>();
            services.AddScoped<ISinavDersKonuService, SinavDersKonuService>();
            services.AddScoped<ISinavDersService, SinavDersService>();
            services.AddScoped<ISinavService, SinavService>();
            services.AddScoped<ISinifDersKonuService, SinifDersKonuService>();
            services.AddScoped<ISinifDersService, SinifDersService>();
            services.AddScoped<ISinifService, SinifService>();
            services.AddScoped<IVeliOgrenciService, VeliOgrenciService>();           
            services.AddScoped<IOgrenciEnvanteriHollandService, OgrenciEnvanteriHollandService>(); 
            services.AddScoped<IOgrenciKendiniDegerlendirmeService, OgrenciKendiniDegerlendirmeService>(); 
            services.AddScoped<IDanismanOgrenciService, DanismanOgrenciService>();

        }
    }
}