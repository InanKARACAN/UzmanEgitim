using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UzmanEgitimDanismanim.Core.Entities;

namespace UzmanEgitimDanismanim.Data.Configurations
{
    class SinavDersKonuConfiguration : BaseConfiguration<SinavDersKonu>, IEntityTypeConfiguration<SinavDersKonu>
    {
        public override void Configure(EntityTypeBuilder<SinavDersKonu> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.SinavDersKonuAdi).IsRequired().HasMaxLength(100);
            builder.ToTable("SinavDersKonu");
        }
    }
}