using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UzmanEgitimDanismanim.Shared.Dtos
{
    public class OgrenciEnvanteriHollandDto : BaseDto, IDto
    {
        public int OgrenciId { get; set; }
        
        [DisplayName("Kuşların nasıl göç ettiğini öğrenmek")]
        public int Soru1 { get; set; }
        [DisplayName("İnsanlara yeni bir hobi öğretmek")] 
        public int Soru2 { get; set; }
        [DisplayName("Hava durumu tahmini için kişisel gözlemleri kullanmak")] 
        public int Soru3 { get; set; }
        [DisplayName("Bitki hastalıklarını incelemek")] 
        public int Soru4 { get; set; }
        [DisplayName("Bankaya yatırılan paranın faizini hesaplamak")] 
        public int Soru5 { get; set; }
        [DisplayName("Resimler tasarlamak ve çizmek")] 
        public int Soru6 { get; set; }
        [DisplayName("Bir iş yaptırmak için parayla adam tutmak")] 
        public int Soru7 { get; set; }
        [DisplayName("Bir bilim müzesini incelemek")] 
        public int Soru8 { get; set; }
        [DisplayName("Gözlük için mercekleri parlatmak")] 
        public int Soru9 { get; set; }
        [DisplayName("Modern yazarların yazı stillerini araştırmak")] 
        public int Soru10 { get; set; }
        [DisplayName("Mikroskop gibi laboratuar aletlerini kullanmak")] 
        public int Soru11 { get; set; }
        [DisplayName("Bir dükkanda envanter tutmak")] 
        public int Soru12 { get; set; }
        [DisplayName("Bir kuş yemliği tasarlamak")] 
        public int Soru13 { get; set; }
        [DisplayName("Bir oyun için takım oluşturma")] 
        public int Soru14 { get; set; }
        [DisplayName("Yeni bir satış kampanyası düzenlemek")] 
        public int Soru15 { get; set; }
        [DisplayName("Bir toplantıyı yönetmek")] 
        public int Soru16 { get; set; }
        [DisplayName("Vitaminlerin hayvanlar üzerindeki etkisini araştırmak")] 
        public int Soru17 { get; set; }
        [DisplayName("Küçük bir işletmeyi idare etmek")] 
        public int Soru18 { get; set; }
        [DisplayName("Bir makinenin nasıl kullanılacağı konusunda talimatlar yazmak")] 
        public int Soru19 { get; set; }
        [DisplayName("Diğer insanlar için iş planlamak")] 
        public int Soru20 { get; set; }
        [DisplayName("Küçük grup tartışmalarına katılmak")] 
        public int Soru21 { get; set; }
        [DisplayName("Yeni bir cerrahi işlem hakkında yazılar okumak")] 
        public int Soru22 { get; set; }
        [DisplayName("Mali bir hesaptaki hataları bulmak")] 
        public int Soru23 { get; set; }
        [DisplayName("Bir rapor taslağındaki hataları bulmak incelemek")] 
        public int Soru24 { get; set; }
        [DisplayName("Planlar ve grafikler yapmak")] 
        public int Soru25 { get; set; }
        [DisplayName("Fırtınadan sonra zarar görmüş bir ağacı onarmak")] 
        public int Soru26 { get; set; }
        [DisplayName("Kusurları bulmak için mamulleri incelemek")] 
        public int Soru27 { get; set; }
        [DisplayName("Telefonla iş idare etmek")] 
        public int Soru28 { get; set; }
        [DisplayName("Acil durumlarda insanlara tardım etmek")] 
        public int Soru29 { get; set; }
        [DisplayName("Bir kuruluşun parayla ilgili bütün işlerini idare etmek")] 
        public int Soru30 { get; set; }
        [DisplayName("Müzik eseri bestelemek veya düzenlemek")] 
        public int Soru31 { get; set; }
        [DisplayName("Filmler için konu müziği bestelemek")] 
        public int Soru32 { get; set; }
        [DisplayName("Yeni kurallar veya politikalar geliştirmek")] 
        public int Soru33 { get; set; }
        [DisplayName("Biyoloji çalışmak")] 
        public int Soru34 { get; set; }
        [DisplayName("Bir politik kurum için kampanyaya katılmak")] 
        public int Soru35 { get; set; }
        [DisplayName("Maddeleri ayırmak, biriktirmek ve saklamak")] 
        public int Soru36 { get; set; }
        [DisplayName("Bir toplum geliştirme projesinde çalışmak")] 
        public int Soru37 { get; set; }
        [DisplayName("Bir daktilonun nasıl tamir edileceğini öğrenmek")] 
        public int Soru38 { get; set; }
        [DisplayName("Dünyanın merkezi, güneş ve yıldızlar hakkında kitaplar okumak")] 
        public int Soru39 { get; set; }
        [DisplayName("Tam doğru zaman tutmak için bir saati ayarlamak")] 
        public int Soru40 { get; set; }
        [DisplayName("Beynin nasıl çalıştığını öğrenmek")] 
        public int Soru41 { get; set; }
        [DisplayName("Yaratıcı fotoğraflar çekmek")] 
        public int Soru42 { get; set; }
        [DisplayName("Masraflara ait hesap kayıtları tutmak")] 
        public int Soru43 { get; set; }
        [DisplayName("Bir bandoda çalmak")] 
        public int Soru44 { get; set; }
        [DisplayName("Bir orkestrada caz müziği çalmak")] 
        public int Soru45 { get; set; }
        [DisplayName("Bir grup veya klüp için bütçe hazırlamak")] 
        public int Soru46 { get; set; }
        [DisplayName("Depremin nedenlerini araştırmak")] 
        public int Soru47 { get; set; }
        [DisplayName("Ünlü bir bilim adamının dersine katılmak")] 
        public int Soru48 { get; set; }
        [DisplayName("Bir proje üzerinde başkaları ile beraber çalışmak")] 
        public int Soru49 { get; set; }
        [DisplayName("Bir sinema filmi senaryosu yazmak")] 
        public int Soru50 { get; set; }
        [DisplayName("Şirket hakkındaki şikayetleri konusunda işçilerle röportaj yapmak")] 
        public int Soru51 { get; set; }
        [DisplayName("Mobilya yapmak")] 
        public int Soru52 { get; set; }
        [DisplayName("Değerli taşları kesmeyi ve parlatmayı öğrenmek")] 
        public int Soru53 { get; set; }
        [DisplayName("Yaralı bir insana ilkyardım yapmak")] 
        public int Soru54 { get; set; }
        [DisplayName("Yerel bir radyo istasyonunda çalınması için müzik parçaları seçmek")] 
        public int Soru55 { get; set; }
        [DisplayName("İl genel meclisinde çalışmak")] 
        public int Soru56 { get; set; }
        [DisplayName("Mali raporları hazırlamak ve yorumlamak")] 
        public int Soru57 { get; set; }
        [DisplayName("Tehlikedeki bir insana yardım etmeye çalışmak")] 
        public int Soru58 { get; set; }
        [DisplayName("Elektronik alet çalıştırmak")] 
        public int Soru59 { get; set; }
        [DisplayName("Çocuklara nasıl oyun oynanacağını veya spor yapılacağını göstermek")] 
        public int Soru60 { get; set; }
        [DisplayName("Bir ustayı televizyon tamir ederken seyretmek")] 
        public int Soru61 { get; set; }
        [DisplayName("Bir magazin hikayesini anlatan çizimler yapmak")] 
        public int Soru62 { get; set; }
        [DisplayName("Ziyaretçilere yol göstermek")] 
        public int Soru63 { get; set; }
        [DisplayName("Diğer insanların bir problemin çözülebileceğine nasıl inandıklarını öğrenmek")] 
        public int Soru64 { get; set; }
        [DisplayName("Bir sergiye gezi düzenlemek")] 
        public int Soru65 { get; set; }
        [DisplayName("Uyuşturucu kullanan insanlara danışmanlık yapmak")] 
        public int Soru66 { get; set; }
        [DisplayName("İş gazeteleri veya dergileri okumak")] 
        public int Soru67 { get; set; }
        [DisplayName("Yıldızların oluşumunu öğrenmek")] 
        public int Soru68 { get; set; }
        [DisplayName("Taksit ödemelerini tahsil etmek")] 
        public int Soru69 { get; set; }
        [DisplayName("Bir slayt veya film projektörünü çalıştırmak")] 
        public int Soru70 { get; set; }
        [DisplayName("Kelebekleri gözlemlemek ve sınıflandırmak")] 
        public int Soru71 { get; set; }
        [DisplayName("Metal bir heykel tasarlamak")] 
        public int Soru72 { get; set; }
        [DisplayName("İnsanlara kanuni doğruları açıklamak")] 
        public int Soru73 { get; set; }
        [DisplayName("Kısa hikayeler yazmak")] 
        public int Soru74 { get; set; }
        [DisplayName("İnsanların mali kararlar vermelerine yardımcı olmak")] 
        public int Soru75 { get; set; }
        [DisplayName("Gelir vergisi kazancını düzenlemek")] 
        public int Soru76 { get; set; }
        [DisplayName("Sertifika, plaket veya taktir belgesi kazanmak")] 
        public int Soru77 { get; set; }
        [DisplayName("Tiyatro oyunu, müzikaller gibi sanatsal etkinliklerin eleştirilerini yazmak")] 
        public int Soru78 { get; set; }
        [DisplayName("Aylık bütçe planı yapmak")] 
        public int Soru79 { get; set; }
        [DisplayName("Bir havuz veya gölde yabani hayatı araştırmak")] 
        public int Soru80 { get; set; }
        [DisplayName("Bir tiyatro oyununda rol almak")] 
        public int Soru81 { get; set; }
        [DisplayName("Bir resim çerçevesi yapmak")] 
        public int Soru82 { get; set; }
        [DisplayName("İş gezilerine çıkmak")] 
        public int Soru83 { get; set; }
        [DisplayName("Orman yangınları için gözetleme yapmak")] 
        public int Soru84 { get; set; }
        [DisplayName("Yeni alışveriş merkezinin tanıtımını yapmak")] 
        public int Soru85 { get; set; }
        [DisplayName("Bir muhasebecilik sistemi kurmak")] 
        public int Soru86 { get; set; }
        [DisplayName("Arkadaşlar arasındaki bir tartışmayı yatıştırmak")] 
        public int Soru87 { get; set; }
        [DisplayName("Birine önemli bir karar vermesinde yardım etmek")] 
        public int Soru88 { get; set; }
        [DisplayName("Taşıma için nakil maliyetlerini hesaplamak")] 
        public int Soru89 { get; set; }
        [DisplayName("Fıkralar ve hikayeler anlatarak insanları eğlendirmek")] 
        public int Soru90 { get; set; }
    }
}