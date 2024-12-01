using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UzmanEgitimDanismanim.Core.Entities;

namespace UzmanEgitimDanismanim.Data.Configurations
{
    class KullaniciRolConfiguration : BaseConfiguration<KullaniciRol>, IEntityTypeConfiguration<KullaniciRol>
    {
        public override void Configure(EntityTypeBuilder<KullaniciRol> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.RolAdi).IsRequired().HasMaxLength(20);
            builder.ToTable("KullaniciRol");
        }
    }
}