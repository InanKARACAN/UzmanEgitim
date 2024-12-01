using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UzmanEgitimDanismanim.Core.Entities;

namespace UzmanEgitimDanismanim.Data.Configurations
{
    class OgrenciDersTakipConfiguration : BaseConfiguration<OgrenciDersTakip>, IEntityTypeConfiguration<OgrenciDersTakip>
    {
        public override void Configure(EntityTypeBuilder<OgrenciDersTakip> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.OgrenciId).IsRequired();
            builder.Property(x => x.SinifDersKonuId).IsRequired();
            builder.ToTable("OgrenciDersTakip");

            builder.HasOne(h => h.Ogrenci)
            .WithMany(w => w.OgrenciDersTakipler)
            .HasForeignKey(k => k.OgrenciId);

            builder.HasOne(r => r.SinifDersKonu)
            .WithMany(w => w.OgrenciDersTakipler)
            .HasForeignKey(k => k.SinifDersKonuId);

            //builder.HasOne(r => r.SinifDers)
            //.WithMany()
            //.OnDelete(DeleteBehavior.Restrict);
        }
    }
}
