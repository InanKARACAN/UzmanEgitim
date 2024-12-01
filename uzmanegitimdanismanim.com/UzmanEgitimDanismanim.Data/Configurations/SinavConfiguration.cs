using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UzmanEgitimDanismanim.Core.Entities;

namespace UzmanEgitimDanismanim.Data.Configurations
{
    class SinavConfiguration : BaseConfiguration<Sinav>, IEntityTypeConfiguration<Sinav>
    {
        public override void Configure(EntityTypeBuilder<Sinav> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.SinavAdi).IsRequired().HasMaxLength(20);
            builder.ToTable("Sinav");
        }
    }
}