using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UzmanEgitimDanismanim.Core.Entities;

namespace UzmanEgitimDanismanim.Data.Configurations
{
    class KullaniciConfiguration : BaseConfiguration<Kullanici>, IEntityTypeConfiguration<Kullanici>
    {
        public override void Configure(EntityTypeBuilder<Kullanici> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Ad).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Soyad).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Eposta).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CepTelefonu).IsRequired().HasMaxLength(14);
            builder.Property(x => x.Sifre).IsRequired().HasMaxLength(50);
            builder.ToTable("Kullanici");
        }
    }
}