namespace UzmanEgitimDanismanim.Core.Entities
{
    public abstract class BaseEntity : IBaseEntity, IEntity
    {
        public DateTime IslemTarihi { get; set; }
        public int IslemYapanKullanici { get; set; }
        public bool Silindi { get; set; }
        public bool Aktif { get; set; }
    }

    public interface IBaseEntity
    {
        public DateTime IslemTarihi { get; set; }
        public int IslemYapanKullanici { get; set; }
        public bool Silindi { get; set; }
        public bool Aktif { get; set; }
    }
}
