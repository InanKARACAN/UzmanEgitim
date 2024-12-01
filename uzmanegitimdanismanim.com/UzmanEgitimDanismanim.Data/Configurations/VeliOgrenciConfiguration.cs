using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UzmanEgitimDanismanim.Core.Entities;

namespace UzmanEgitimDanismanim.Data.Configurations
{
    class VeliOgrenciConfiguration : BaseConfiguration<VeliOgrenci>, IEntityTypeConfiguration<VeliOgrenci>
    {
        public override void Configure(EntityTypeBuilder<VeliOgrenci> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.VeliId).IsRequired();
            builder.Property(x => x.OgrenciId).IsRequired();
            builder.ToTable("VeliOgrenci");

            builder.HasOne(r => r.Veli)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Ogrenci)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
