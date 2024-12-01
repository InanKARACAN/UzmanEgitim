using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UzmanEgitimDanismanim.Core.Entities;

namespace UzmanEgitimDanismanim.Data.Configurations
{
    class SinifDersConfiguration : BaseConfiguration<SinifDers>, IEntityTypeConfiguration<SinifDers>
    {
        public override void Configure(EntityTypeBuilder<SinifDers> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.SinifDersAdi).IsRequired().HasMaxLength(50);
            builder.ToTable("SinifDers");
        }
    }
}