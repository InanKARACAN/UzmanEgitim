using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UzmanEgitimDanismanim.Core.Entities;

namespace UzmanEgitimDanismanim.Data.Configurations
{
    class OgrenciEnvanteriHollandConfiguration : BaseConfiguration<OgrenciEnvanteriHolland>, IEntityTypeConfiguration<OgrenciEnvanteriHolland>
    {
        public override void Configure(EntityTypeBuilder<OgrenciEnvanteriHolland> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.OgrenciId).IsRequired();
            builder.ToTable("OgrenciEnvanteriHolland");

            builder.HasOne(h => h.Ogrenci)
            .WithMany(w => w.OgrenciEnvanteriHollandlar)
            .HasForeignKey(k => k.OgrenciId);

        }
    }
}
