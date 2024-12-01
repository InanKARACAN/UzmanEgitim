using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UzmanEgitimDanismanim.Core.Entities;

namespace UzmanEgitimDanismanim.Data.Configurations
{
    class SinavDersConfiguration : BaseConfiguration<SinavDers>, IEntityTypeConfiguration<SinavDers>
    {
        public override void Configure(EntityTypeBuilder<SinavDers> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.SinavDersAdi).IsRequired().HasMaxLength(50);
            builder.ToTable("SinavDers");
        }
    }
}