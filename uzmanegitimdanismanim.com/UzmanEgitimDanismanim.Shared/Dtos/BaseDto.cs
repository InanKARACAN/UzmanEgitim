namespace UzmanEgitimDanismanim.Shared.Dtos
{
    public class BaseDto
    {
        public int Id { get; set; }
        public string EncryptedId { get; set; }
        public DateTime IslemTarihi { get; set; }
        public int IslemYapanKullanici { get; set; }
        public bool Silindi { get; set; }
        public bool Aktif { get; set; }
    }
}