using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UzmanEgitimDanismanim.Core.Entities;

namespace UzmanEgitimDanismanim.Data.Configurations
{
    class OgrenciSinavTakipConfiguration : BaseConfiguration<OgrenciSinavTakip>, IEntityTypeConfiguration<OgrenciSinavTakip>
    {
        public override void Configure(EntityTypeBuilder<OgrenciSinavTakip> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.OgrenciId).IsRequired();
            builder.Property(x => x.SinavId).IsRequired();
            builder.Property(x => x.SinavAdi).IsRequired().HasMaxLength(50);
            builder.ToTable("OgrenciSinavTakip");

            //builder.HasOne(r => r.Ogrenci)
            //.WithMany()
            //.OnDelete(DeleteBehavior.Restrict);

            //builder.HasOne(r => r.Sinif)
            //.WithMany()
            //.OnDelete(DeleteBehavior.Restrict);

            //builder.HasOne(r => r.SinifDers)
            //.WithMany()
            //.OnDelete(DeleteBehavior.Restrict);
        }
    }
}
