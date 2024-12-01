using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UzmanEgitimDanismanim.Core.Entities;

namespace UzmanEgitimDanismanim.Data.Configurations
{
    class KurumConfiguration : BaseConfiguration<Kurum>, IEntityTypeConfiguration<Kurum>
    {
        public override void Configure(EntityTypeBuilder<Kurum> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.KurumAdi).IsRequired().HasMaxLength(200);
            builder.Property(x => x.KurumEposta).IsRequired().HasMaxLength(50);
            builder.Property(x => x.KurumTel).IsRequired().HasMaxLength(10);
            builder.Property(x => x.KurumAdres).HasMaxLength(200);
            builder.ToTable("Kurum");
        }
    }
}
