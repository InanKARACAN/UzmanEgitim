using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UzmanEgitimDanismanim.Core.Entities;

namespace UzmanEgitimDanismanim.Data.Configurations
{
    class DanismanOgrenciConfiguration : BaseConfiguration<DanismanOgrenci>, IEntityTypeConfiguration<DanismanOgrenci>
    {
        public override void Configure(EntityTypeBuilder<DanismanOgrenci> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.DanismanId).IsRequired();
            builder.Property(x => x.OgrenciId).IsRequired();
            builder.ToTable("DanismanOgrenci");

            builder.HasOne(r => r.Danisman)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Ogrenci)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
