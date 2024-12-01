using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UzmanEgitimDanismanim.Core.Entities;

namespace UzmanEgitimDanismanim.Data.Configurations
{
    class OgrenciSoruTakipConfiguration : BaseConfiguration<OgrenciSoruTakip>, IEntityTypeConfiguration<OgrenciSoruTakip>
    {
        public override void Configure(EntityTypeBuilder<OgrenciSoruTakip> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.OgrenciId).IsRequired();
            builder.Property(x => x.SinifDersKonuId).IsRequired();
            builder.ToTable("OgrenciSoruTakip");

            builder.HasOne(h => h.Ogrenci)
            .WithMany(w => w.OgrenciSoruTakipler)
            .HasForeignKey(k => k.OgrenciId);

            builder.HasOne(r => r.SinifDersKonu)
            .WithMany(w => w.OgrenciSoruTakipler)
            .HasForeignKey(k => k.SinifDersKonuId);
        }
    }
}