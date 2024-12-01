using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UzmanEgitimDanismanim.Core.Entities;

namespace UzmanEgitimDanismanim.Data.Configurations
{
    class OgrenciSinavTakipCozumConfiguration : BaseConfiguration<OgrenciSinavTakipCozum>, IEntityTypeConfiguration<OgrenciSinavTakipCozum>
    {
        public override void Configure(EntityTypeBuilder<OgrenciSinavTakipCozum> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.OgrenciSinavTakipId).IsRequired();
            builder.Property(x => x.SinavDersId).IsRequired();
            builder.ToTable("OgrenciSinavTakipCozum");

            builder.HasOne(h => h.OgrenciSinavTakip)
           .WithMany(w => w.OgrenciSinavTakipCozumler)
           .HasForeignKey(k => k.OgrenciSinavTakipId);

            builder.HasOne(r => r.SinavDers)
           .WithMany()
           .OnDelete(DeleteBehavior.Restrict);

            // builder.HasOne(h => h.SinavDers)
            //.WithMany(w => w.OgrenciSinavTakipCozumler)
            //.HasForeignKey(k => k.SinavDersId);



        }
    }
}