using Microsoft.EntityFrameworkCore;
using UzmanEgitimDanismanim.Core.Entities;

namespace UzmanEgitimDanismanim.Data
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<KullaniciRol> KullaniciRoller { get; set; }
        public DbSet<Kurum> Kurumlar { get; set; }
        public DbSet<OgrenciDokuman> OgrenciDokumanlar { get; set; }
        public DbSet<OgrenciDersTakip> OgrenciDersTakipler { get; set; }
        public DbSet<OgrenciSoruTakip> OgrenciSoruTakipler { get; set; }
        public DbSet<OgrenciGorevTakip> OgrenciGorevTakipler { get; set; }
        //public DbSet<OgrenciDersTakipCozum> OgrenciDersTakipCozumler { get; set; }
        public DbSet<OgrenciSinavTakip> OgrenciSinavTakipler { get; set; }
        public DbSet<OgrenciSinavTakipCozum> OgrenciSinavTakipCozumler { get; set; }
        public DbSet<OgrenciSinif> OgrenciSiniflar { get; set; }
        public DbSet<Sinav> Sinavlar { get; set; }
        public DbSet<SinavDers> SinavDersler { get; set; }
        public DbSet<SinavDersKonu> SinavDersKonular { get; set; }
        public DbSet<Sinif> Siniflar { get; set; }
        public DbSet<SinifDers> SinifDersler { get; set; }
        public DbSet<SinifDersKonu> SinifDersKonular { get; set; }
        public DbSet<VeliOgrenci> VeliOgrenciler { get; set; }
        public DbSet<OgrenciEnvanteriHolland> OgrenciEnvanteriHollandlar { get; set; }
        public DbSet<OgrenciKendiniDegerlendirme> OgrenciKendiniDegerlendirmeler{ get; set; }
        public DbSet<DanismanOgrenci> DanismanOgrenciler { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Bütün IEntityTypeConfiguration olan Config Dosyalarını bind ediyor. Tek tek eklemeye gerek kalmıyor.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlDbContext).Assembly);
        }
    }
}
