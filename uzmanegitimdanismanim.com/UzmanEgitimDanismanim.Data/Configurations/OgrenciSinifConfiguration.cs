using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UzmanEgitimDanismanim.Core.Entities;

namespace UzmanEgitimDanismanim.Data.Configurations
{
    class OgrenciSinifConfiguration : BaseConfiguration<OgrenciSinif>, IEntityTypeConfiguration<OgrenciSinif>
    {
        public override void Configure(EntityTypeBuilder<OgrenciSinif> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.OgrenciId).IsRequired();
            builder.Property(x => x.SinifId).IsRequired();
            builder.ToTable("OgrenciSinif");

            builder.HasOne(r => r.Ogrenci)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Sinif)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}