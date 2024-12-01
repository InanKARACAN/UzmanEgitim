using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UzmanEgitimDanismanim.Core.Entities;

namespace UzmanEgitimDanismanim.Data.Configurations
{
    class OgrenciDokumanConfiguration : BaseConfiguration<OgrenciDokuman>, IEntityTypeConfiguration<OgrenciDokuman>
    {
        public override void Configure(EntityTypeBuilder<OgrenciDokuman> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.OgrenciId).IsRequired();
            builder.ToTable("OgrenciDokuman");

            builder.HasOne(h => h.Ogrenci)
            .WithMany(w => w.OgrenciDokumanlar)
            .HasForeignKey(k => k.OgrenciId);


        }
    }
}
