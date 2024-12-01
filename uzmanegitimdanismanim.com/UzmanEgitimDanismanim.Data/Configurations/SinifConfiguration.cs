using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UzmanEgitimDanismanim.Core.Entities;

namespace UzmanEgitimDanismanim.Data.Configurations
{
    class SinifConfiguration : BaseConfiguration<Sinif>, IEntityTypeConfiguration<Sinif>
    {
        public override void Configure(EntityTypeBuilder<Sinif> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.SinifAdi).IsRequired().HasMaxLength(20);
            builder.ToTable("Sinif");
        }
    }
}