using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UzmanEgitimDanismanim.Core.Entities;

namespace UzmanEgitimDanismanim.Data.Configurations
{
    class OgrenciGorevTakipConfiguration : BaseConfiguration<OgrenciGorevTakip>, IEntityTypeConfiguration<OgrenciGorevTakip>
    {
        public override void Configure(EntityTypeBuilder<OgrenciGorevTakip> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.OgrenciId).IsRequired();
            builder.Property(x => x.TumGun).HasDefaultValue(false);
            builder.ToTable("OgrenciGorevTakip");

            builder.HasOne(h => h.Ogrenci)
            .WithMany(w => w.OgrenciGorevTakipler)
            .HasForeignKey(k => k.OgrenciId);
        }
    }
}