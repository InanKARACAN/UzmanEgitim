using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UzmanEgitimDanismanim.Core.Entities;

namespace UzmanEgitimDanismanim.Data.Configurations
{
    class OgrenciKendiniDegerlendirmeConfiguration : BaseConfiguration<OgrenciKendiniDegerlendirme>, IEntityTypeConfiguration<OgrenciKendiniDegerlendirme>
    {
        public override void Configure(EntityTypeBuilder<OgrenciKendiniDegerlendirme> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.OgrenciId).IsRequired();
            builder.ToTable("OgrenciKendiniDegerlendirme");

            builder.HasOne(h => h.Ogrenci)
            .WithMany(w => w.OgrenciKendiniDegerlendirmeler)
            .HasForeignKey(k => k.OgrenciId);

        }
    }
}
