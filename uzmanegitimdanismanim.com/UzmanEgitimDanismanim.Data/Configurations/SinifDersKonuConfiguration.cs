using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UzmanEgitimDanismanim.Core.Entities;

namespace UzmanEgitimDanismanim.Data.Configurations
{
    class SinifDersKonuConfiguration : BaseConfiguration<SinifDersKonu>, IEntityTypeConfiguration<SinifDersKonu>
    {
        public override void Configure(EntityTypeBuilder<SinifDersKonu> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.SinifDersKonuAdi).IsRequired().HasMaxLength(100);
            builder.ToTable("SinifDersKonu");
        }
    }
}