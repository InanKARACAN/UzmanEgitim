using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UzmanEgitimDanismanim.Shared.Dtos
{
    public class OgrenciKendiniDegerlendirmeDto : BaseDto, IDto
    {
        public int OgrenciId { get; set; }

        [DisplayName("Bir açının kaç derece olduğunu doğru bir biçimde tahmin edebiliyor musunuz?")]
        public int Soru1 { get; set; }
        [DisplayName("Bir yazıyı hızlı bir biçimde söyleyebiliyor musunuz?")]
        public int Soru2 { get; set; }
        [DisplayName("Kalemleri düzgün bir biçimde söyleyebiliyor musunuz?")]
        public int Soru3 { get; set; }
        [DisplayName("Sıfır, eşitlik, sonsuz gibi matematik kavramları kolaylıkla öğrenebildiniz mi?")]
        public int Soru4 { get; set; }
        [DisplayName("Birbirine çok benzeyen karmaşık iki şekil arasındaki küçük farkı görebiliyor musunuz?")]
        public int Soru5 { get; set; }
        [DisplayName("Bir problemin çözüm yolunu öğrendikten sonra benzer problemleri çözebiliyor musunuz?")]
        public int Soru6 { get; set; }
        [DisplayName("Bir parçayı bir kere okuduktan sonra hemen özetleyebiliyor musunuz?")]
        public int Soru7 { get; set; }
        [DisplayName("Sizin düzeyinizde bir matematik kitabından bir problemin çözüm yolunu kolaylıkla bulabiliyor musunuz?")]
        public int Soru8 { get; set; }
        [DisplayName("Karmaşık bir geometrik şeklin sağa, sola, yukarıya ve aşağıya kaydırılması ile alacağı durumu göz önünde canlandırabilir misiniz?")]
        public int Soru9 { get; set; }
        [DisplayName("Açınımı verilmiş bir geometrik cismin kapalı halini göz önünde canlandırabilir misiniz?")]
        public int Soru10 { get; set; }
        [DisplayName("Kelime bilginiz, sözcük dağarcınız zengin midir?")]
        public int Soru11 { get; set; }
        [DisplayName("Bir problemin çözümünü veren denklemi hemen kurabilir misiniz?")]
        public int Soru12 { get; set; }
        [DisplayName("Öğrendiğiniz matematik kural ve ilkeleri fizik ve kimya dersinde karşılaştığınız problemlere uygulaya biliyor musunuz?")]
        public int Soru13 { get; set; }
        [DisplayName("Matematik dersinde öğrendiğiniz ilkeleri ilk karşılaştığınız bir probleme uygulayıp çözümünü bulabiliyor musunuz?")]
        public int Soru14 { get; set; }
        [DisplayName("Sık rastlanmayan türden bir geometrik cismin açınımını çizebilir misiniz?")]
        public int Soru15 { get; set; }
        [DisplayName("Logaritma, sinüs gibi sembollerle yazılmış yazıları kolaylıkla okuyabiliyor musunuz?")]
        public int Soru16 { get; set; }
        [DisplayName("Okuduğunuz bir parçada belirtilen fikirler arasında ilişki kurabiliyor musunuz?")]
        public int Soru17 { get; set; }
        [DisplayName("Matematik bulmacaları çözer misiniz?")]
        public int Soru18 { get; set; }
        [DisplayName("Karmaşık bir geometrik şeklin küçük bir parçasını  bütünden soyutlayarak algılayabiliyor musunuz?")]
        public int Soru19 { get; set; }
        [DisplayName("Bir problemin, size öğretilen çözüm yolundan farklı çözüm yollarını bulabiliyor musunuz?")]
        public int Soru20 { get; set; }
        [DisplayName("Bir konuda edindiğiniz bilgileri, kendi sözcüklerimizle başkalarına aktarabiliyor musunuz?")]
        public int Soru21 { get; set; }
        [DisplayName("Bir evin planına baktığınızda, evin yapılmış halini göz önünde canlandırabiliyor musunuz?")]
        public int Soru22 { get; set; }
        [DisplayName("Bilginiz sembollerle yazılmış, ama daha önce hiç görmediğiniz bir matematik kitabını rahatlıkla okuyabiliyor musunuz?")]
        public int Soru23 { get; set; }
        [DisplayName("Bir konuyu söz ve yazı ile anlatırken fikirleri doğru bir sıra ile verebiliyor musunuz?")]
        public int Soru24 { get; set; }
        [DisplayName("Yabancısı olduğunuz kapalı bir mekanda yönünüzü kolaylıkla bulabilir misiniz?")]
        public int Soru25 { get; set; }
        [DisplayName("Bir yazıdaki fikir ve ifade hatalarını kolaylıkla görebiliyor musunuz?")]
        public int Soru26 { get; set; }
        [DisplayName("Gelişi güzel parçalara ayrılmış bir şekli yeniden ve çabucak oluşturabiliyor musunuz?")]
        public int Soru27 { get; set; }
        [DisplayName("Akıcı bir üslupla güzel yazı yazabiliyor musunuz?")]
        public int Soru28 { get; set; }
        [DisplayName("Bir makinanın şemasına bakarak makinayı kurabilir misiniz?")]
        public int Soru29 { get; set; }
        [DisplayName("Bir yazının ana ve yardımcı fikirlerini kolaylıkla bulabiliyor musunuz?")]
        public int Soru30 { get; set; }
        [DisplayName("Başkalarına, kişisel sorunlarının çözümünde yardımcı olabiliyor musunuz?")]
        public int Soru31 { get; set; }
        [DisplayName("El sanatları ya da resim kursuna gitmek ister misiniz?")]
        public int Soru32 { get; set; }
        [DisplayName("İnanç ve düşüncelerinizi başkalarına kolaylıkla aktarılabilir mi?")]
        public int Soru33 { get; set; }
        [DisplayName("Televizyondaki reklâmları eleştirir, daha iyi nasıl yapılabileceğini düşünür müsünüz?")]
        public int Soru34 { get; set; }
        [DisplayName("Çeşitli kültürlerde çocuk yetiştirme yöntemlerini konulu bir konferansı dinlemek ister misiniz?")]
        public int Soru35 { get; set; }
        [DisplayName("Ünlü yaşamlarının hayatlarını okur musunuz?")]
        public int Soru36 { get; set; }
        [DisplayName("Her işinizi günü gününe yapar mısınız?")]
        public int Soru37 { get; set; }
        [DisplayName("Mekanik bulmacalar çözer misiniz?")]
        public int Soru38 { get; set; }
        [DisplayName("Evcil hayvanların hangi koşul ve ortamlarda daha iyi geliştirdiklerini inceler misiniz?")]
        public int Soru39 { get; set; }
        [DisplayName("Gelecekte kendinizi bir laboratuvarda araştırmacı olarak düşlediğiniz olur mu?")]
        public int Soru40 { get; set; }
        [DisplayName("Müzik aletleri sergisini gezer misiniz?")]
        public int Soru41 { get; set; }
        [DisplayName("Pazarlama ve satış yöntemlerini öğreten bir kursa devam etmek ister misiniz?")]
        public int Soru42 { get; set; }
        [DisplayName("Pazarlama ve satış yöntemlerini öğreten bir kursa devam etmek ister misiniz?")]
        public int Soru43 { get; set; }
        [DisplayName("Ünlü sanatçıların, ressamların hayatını inceler misiniz?")]
        public int Soru44 { get; set; }
        [DisplayName("Söz ve davranışlarımızın başkaları üzerindeki etkisini öğrenmeye çalışır mısınız?")]
        public int Soru45 { get; set; }
        [DisplayName("Yaşlılar yurdunda eğlence günleri düzenlemek ister misiniz?")]
        public int Soru46 { get; set; }
        [DisplayName("Edebiyat ödüllerini izler, ödül alan eserleri okur musunuz?")]
        public int Soru47 { get; set; }
        [DisplayName("Ufak tefek besteler yapar mısınız?")]
        public int Soru48 { get; set; }
        [DisplayName("Elektrikli oyuncakların nasıl işlediğini inceler misiniz?")]
        public int Soru49 { get; set; }
        [DisplayName("Ailenin tarih boyunca değişimi konulu bir makaleyi okumaktan hoşlanır mısınız?")]
        public int Soru50 { get; set; }
        [DisplayName("Tropikal çiçeklerin evlerde nasıl yetiştirileceği konulu bir konferansı dinlemeye gider misiniz?")]
        public int Soru51 { get; set; }
        [DisplayName("Satranç oynar mısınız?")]
        public int Soru52 { get; set; }
        [DisplayName("Evleri dolaşıp, bir ürünün tanıtımını yapmaktan hoşlanır mısınız?")]
        public int Soru53 { get; set; }
        [DisplayName("Daktilo edilmiş bir yazının hatalarını düzeltmekten hoşlanır mısınız?")]
        public int Soru54 { get; set; }
        [DisplayName("Şiir yazmayı hiç denediniz mi?")]
        public int Soru55 { get; set; }
        [DisplayName("İnsan hakları konulu bir kompozisyon yazmak ister misiniz?")]
        public int Soru56 { get; set; }
        [DisplayName("Her türlü araç ve gereç sağlansa bir radyo yapmayı dener misiniz?")]
        public int Soru57 { get; set; }
        [DisplayName("Fizik, kimya ya da matematik alanında bir sorunla ilgili inceleme  ya da proje yapar mısınız?")]
        public int Soru58 { get; set; }
        [DisplayName("Bir çiftliğin yöneticisi olmayı düşünür müsünüz?")]
        public int Soru59 { get; set; }
        [DisplayName("Çeşitli ülkelerin halka şarkılarını tanıtan program izler misiniz?")]
        public int Soru60 { get; set; }
        [DisplayName("Konserleri, müzik programlarını izler misiniz?")]
        public int Soru61 { get; set; }
        [DisplayName("Boş vakitlerinizde  yoksul çocuklara parasız ders verir misiniz?")]
        public int Soru62 { get; set; }
        [DisplayName("Sanat sohbetlerine katılır mısınız?")]
        public int Soru63 { get; set; }
        [DisplayName("Tahta ve metalden ev eşyaları yapar mısınız?")]
        public int Soru64 { get; set; }
        [DisplayName("Gazeteler için ilginç haberler derlemek ister misiniz?")]
        public int Soru65 { get; set; }
        [DisplayName("Hikaye, deneme, anı yazmayı denediniz mi?")]
        public int Soru66 { get; set; }
        [DisplayName("Bir iyin ince ayrıntıları ile uğraşır mısınız?")]
        public int Soru67 { get; set; }
        [DisplayName("Tartışmalarda güçlü kanıtlar bularak görüşünüzü karşınızdakilere kabul ettirebilir misiniz?")]
        public int Soru68 { get; set; }
        [DisplayName("Yaz aylarında bir dükkan ya da ticarethanede kendi isteğinizle çalıştınız mı?")]
        public int Soru69 { get; set; }
        [DisplayName("Bir hastanede gönüllü olarak çalışmak ister misiniz?")]
        public int Soru70 { get; set; }
        [DisplayName("Mimarlık ya da genel olarak sanat tarihi ile ilgili bir kitabı zevk duyarak okur musunuz?")]
        public int Soru71 { get; set; }
        [DisplayName("Bir müzik aleti çalar mısınız?")]
        public int Soru72 { get; set; }
        [DisplayName("Bahçede kaliteli meyve yetiştirmek ister misiniz?")]
        public int Soru73 { get; set; }
        [DisplayName("Çeşitli hayvan ve bitkilerin yaşayışını inceler misiniz?")]
        public int Soru74 { get; set; }
        [DisplayName("Çocukluğunuzda arkadaşlarınıza ciklet, çikolakta,bilye gibi şeyler sattınız mı?")]
        public int Soru75 { get; set; }
        [DisplayName("Okulda münazaralara katılır mısınız?")]
        public int Soru76 { get; set; }
        [DisplayName("Bir evi veya salonu süslemekten hoşlanır mısınız?")]
        public int Soru77 { get; set; }
        [DisplayName("Başkalarına dinletilecek düzeyde bir müzik aleti çalabiliyor musunuz?")]
        public int Soru78 { get; set; }
        [DisplayName("Felakete uğrayan insanlar için yardım kampanyalarına katılır mısınız?")]
        public int Soru79 { get; set; }
        [DisplayName("Bir kamp veya pikniğe gittiğinizde, çevredeki hayvan ve bitkileri inceler misiniz?")]
        public int Soru80 { get; set; }
        [DisplayName("Okul gazetesine yazı yazar mısınız?")]
        public int Soru81 { get; set; }
        [DisplayName("Gittiğiniz bir kentte insanların adetlerini inceler misiniz?")]
        public int Soru82 { get; set; }
        [DisplayName("Model uçak yapmaya çalışır mısınız?")]
        public int Soru83 { get; set; }
        [DisplayName("Fizik ve kimya problemleri çözmekten zevk alır mısınız?")]
        public int Soru84 { get; set; }
        [DisplayName("Çeşitli yazarların üslûp özelliklerini inceler misiniz?")]
        public int Soru85 { get; set; }
        [DisplayName("Resim ya da elişleri yarışmalarına katılır mısınız?")]
        public int Soru86 { get; set; }
        [DisplayName("Konuşurken çevrenizdeki insanların ilgisini çekebilir ve görüşlerinizi onlara kabul ettirebilir misiniz?")]
        public int Soru87 { get; set; }
        [DisplayName("Müzik yarışmalarına katılır mısınız?")]
        public int Soru88 { get; set; }
        [DisplayName("Ödevlerinizi zamanında, düzgün ve temiz bir biçimde yapar mısınız?")]
        public int Soru89 { get; set; }
        [DisplayName("Okul kantinini ya da kooperatifini yönetmek ister misiniz?")]
        public int Soru90 { get; set; }
        [DisplayName("Sakatlara beceri kazandırma kursunda gönüllü olarak çalışmak ister misiniz?")]
        public int Soru91 { get; set; }
        [DisplayName("İşçilerin verimini arttırıcı yöntemler konulu bir makaleyi okur musunuz?")]
        public int Soru92 { get; set; }
        [DisplayName("Evde bozulan aletleri onarır mısınız?")]
        public int Soru93 { get; set; }
        [DisplayName("Deniz dibindeki hayatı gösteren bir filmi ilgi ve dikkatle izler misiniz?")]
        public int Soru94 { get; set; }
        [DisplayName("Yeni çiçek türleri yetiştirmeyi dener misiniz?")]
        public int Soru95 { get; set; }
        [DisplayName("Bir makinanın (Örnek, elektrik motoru) evriminin gösteren bir sergiyi gezmek ister misiniz?")]
        public int Soru96 { get; set; }
        [DisplayName("Türkiye’nin nüfus özelliklerini inceleyen bir araştırma ekibinde çalışmak ister misiniz?")]
        public int Soru97 { get; set; }
        [DisplayName("Yaptığınız herhangi bir işin temiz ve düzenli olması için özen gösterir misiniz?")]
        public int Soru98 { get; set; }
        [DisplayName("Gazetelerde edebiyat ve tiyatro eleştirilerini okur musunuz?")]
        public int Soru99 { get; set; }
        [DisplayName("Sizin gibi düşünmeyen insanları ikna etmek için uzun tartışmalara girer misiniz?")]
        public int Soru100 { get; set; }
        [DisplayName("Altın, hisse senedi ve tahvil satışları ile ilgili konuşmalara katılır mısınız?")]
        public int Soru101 { get; set; }
        [DisplayName("Köy kadınlarına çocuk bakım yöntemlerini anlamak ister misiniz?")]
        public int Soru102 { get; set; }
        [DisplayName("Müzik akımlarını izler misiniz?")]
        public int Soru103 { get; set; }
        [DisplayName("Boş vakitlerinizde çiçek, nakış, resim, heykel, karikatür vb. yapar mısınız ?")]
        public int Soru104 { get; set; }
        [DisplayName("Vahşi hayvanların hayvanat bahçesine uyumu konulu bir makaleyi okur musunuz?")]
        public int Soru105 { get; set; }
        [DisplayName("Ünlü bilim adamlarının hayatını inceler misiniz?")]
        public int Soru106 { get; set; }
        [DisplayName("Bir makinenin işlevini geliştirici yöntemler düşünür müsünüz?")]
        public int Soru107 { get; set; }
        [DisplayName("Çevrenizdeki çeşitle makine ve cihazların bakımını yapar, onları bozmadan, iyi bir biçimde kullanır mısınız?")]
        public int Soru108 { get; set; }
        [DisplayName("Mektupları, makbuzları, eski okul karnelerini vb. kağıtları saklar mısınız?")]
        public int Soru109 { get; set; }
        [DisplayName("Gazetelerde karlı yatırım alanları ile ilgili haberleri izler misiniz?")]
        public int Soru110 { get; set; }
        [DisplayName("Suçlu çocukları topluma kazandırma programında çalışmak ister misiniz?")]
        public int Soru111 { get; set; }
        [DisplayName("Müzik dersleri alır mısınız ya da müzik dersini seçer misiniz?")]
        public int Soru112 { get; set; }
        [DisplayName("Uzay araçlarının, roketlerinin evrimini gösteren bir sergiyi gezmek ister misiniz?")]
        public int Soru113 { get; set; }
        [DisplayName("Evde bir hayvan (kuş, balık, kedi vb.) besler, bakımını yapar mısınız?")]
        public int Soru114 { get; set; }
        [DisplayName("Çatışmaları yatıştırmada arabuluculuk yapar mısınız?")]
        public int Soru115 { get; set; }
        [DisplayName("Edebiyatçılarla yapılmış röportajları izle misiniz?")]
        public int Soru116 { get; set; }
        [DisplayName("En son bilimsel buluşlarla ilgili bir makaleyi okur musunuz?")]
        public int Soru117 { get; set; }
        [DisplayName("Çevrenizdeki insanların davranışlarının nedenlerini araştırır mısınız?")]
        public int Soru118 { get; set; }
        [DisplayName("Edebiyat tartışmalarına katılır mısınız?")]
        public int Soru119 { get; set; }
        [DisplayName("Sanat eserlerini inceler, özelliklerini anlamaya çalışır mısınız?")]
        public int Soru120 { get; set; }
        [DisplayName("Yoksullara yardım derneklerinden birinde çalışmak ister misiniz?")]
        public int Soru121 { get; set; }
        [DisplayName("İnsanların satın alma eğilimlerini inceler misiniz?")]
        public int Soru122 { get; set; }
        [DisplayName("Çevrenizde hazır cevap bir insan olarak tanınır mısınız?")]
        public int Soru123 { get; set; }
        [DisplayName("Saksıda çiçek yetiştirir misiniz?")]
        public int Soru124 { get; set; }
        [DisplayName("Aldığınız her şeyin ya da yaptığınız her işin düzenli bir biçemde kaydını tutar mısınız?")]
        public int Soru125 { get; set; }
        [DisplayName("Roman, hikâye, şiir okur musunuz?")]
        public int Soru126 { get; set; }
        [DisplayName("Televizyonda ekonomi ile ilgili haberleri ve açık oturumları izler misiniz?")]
        public int Soru127 { get; set; }
        [DisplayName("Güzel konuşma ve başkalarını ikna edebilme gücünü geliştirici kurslara katılır mısınız?")]
        public int Soru128 { get; set; }
        [DisplayName("Bilimsel proje sergilerini gezer misiniz?")]
        public int Soru129 { get; set; }
        [DisplayName("Havuzlarda balık üretme yöntemlerini gösteren bir filmi ilgi ile izler misiniz?")]
        public int Soru130 { get; set; }
        [DisplayName("Meydana getirilen herhangi bir el işine estetik bir yön, bir güzellik vermeye çalışır mısınız?")]
        public int Soru131 { get; set; }
        [DisplayName("Gözleri görmeyen bir kimseye kitap okur musunuz?")]
        public int Soru132 { get; set; }
        [DisplayName("Yazılarınızı, notlarınızı konularına göre sınıflar ve dosyalar mısınız?")]
        public int Soru133 { get; set; }
        [DisplayName("İnsanların duygularını ve eğilimlerini inceler misiniz?")]
        public int Soru134 { get; set; }
        [DisplayName("Resim sergisini, sanat galerilerini gezer misiniz?")]
        public int Soru135 { get; set; }
        [DisplayName("Ünlü bestecilerin hayatını inceler misiniz?")]
        public int Soru136 { get; set; }
        [DisplayName("Kamuoyu araştırmaları yapan bir kurumda araştırmacı olarak çalışmak ister misiniz?")]
        public int Soru137 { get; set; }
        [DisplayName("Alet ve makine desenleri çizebilir misiniz?")]
        public int Soru138 { get; set; }
        [DisplayName("Gelir harcamalarınızın ayrıntılı olarak hesabını tutar mısınız?")]
        public int Soru139 { get; set; }
        [DisplayName("Kendinizi genellikle mutlu ve rahat hisseder misiniz?")]
        public int Soru140 { get; set; }
        [DisplayName("Ünlü düşünürlerin ve toplum liderlerinin hayatlarını inceler misiniz?")]
        public int Soru141 { get; set; }
        [DisplayName("Grup halinde yapılan işleri bireysel işlere tercih eder misiniz?")]
        public int Soru142 { get; set; }
        [DisplayName("Bir iş yaparken ya da bir geziye çıktığınızda, önceden yaptığınız planın dışına çıkmak durumunda kalmak sizi rahatsız eder mi?")]
        public int Soru143 { get; set; }
        [DisplayName("Alanınızda üstün başarı göstererek adınızı herkese duyurmak sizce önemli midir?")]
        public int Soru144 { get; set; }
        [DisplayName("“İnsan gönlü neyi çekerse onu yapılmalıdır. Zevki erteleyerek kendini çalışmaya insan yaşamayı unutabilir” diye düşünür müsünüz?")]
        public int Soru145 { get; set; }
        [DisplayName("Bir salona girdiğinizde bütün başların size çevrilmesi ve sizden bahsedebilmesi hoşunuza gider mi?")]
        public int Soru146 { get; set; }
        [DisplayName("Başkaları ile işbirliği halinde çalışmakla daha iyi bir iş ortaya koyma imkanı bulacağınıza inanır mısınız?")]
        public int Soru147 { get; set; }
        [DisplayName("Bir işin her yönünü kendiniz yaparak ya da yapılmasını planlayarak işin tümüne hakim olmaktan hoşlanır mısınız?")]
        public int Soru148 { get; set; }
        [DisplayName("Kendinizi yetenekli gördüğünüz herhangi bir alanda yarışmalara katılır mısınız?")]
        public int Soru149 { get; set; }
        [DisplayName("Öğrendiğiniz bir şeyi uygulamaya kalktığınızda, kendinizden bazı yenilikler katar mısınız?")]
        public int Soru150 { get; set; }
        [DisplayName("Bir konuda başkalarının ne düşündüğünü veya bir işi nasıl yaptığını bilmeye önem verir misiniz?")]
        public int Soru151 { get; set; }
        [DisplayName("Bir işe girince on ya da yirmi yıl sonra nereye geleceğinizi şimdiden bilmeye önem verir misiniz?")]
        public int Soru152 { get; set; }
        [DisplayName("Yemeklerinizi hep belli saatlerde ve alıştığınız şekilde yemekten hoşlanır mısınız?")]
        public int Soru153 { get; set; }
        [DisplayName("Bir işe başlamadan önce bütün ayrıntıları önceden planlar ve planlanan işleri aynen uygular mısınız?")]
        public int Soru154 { get; set; }
        [DisplayName("Mesleğinizin yenilikler yapmaya olanak verecek bir meslek olması sizce önemli midir?")]
        public int Soru155 { get; set; }
        [DisplayName("Hayal gücünüz zengin midir?")]
        public int Soru156 { get; set; }
        [DisplayName("Mutlaka yüksek puanla öğrenci alan bir kurumda yükseköğrenim görmeniz gerektiğine inanıyor musunuz?")]
        public int Soru157 { get; set; }
        [DisplayName("Kendi başınıza karar vermekte güçlük çeker misiniz?")]
        public int Soru158 { get; set; }
        [DisplayName("Çevrenizde gördüğünüz sorunlara kimsenin bulamadığı değişik ve geçerli ve çözüm yolları arar mısınız?")]
        public int Soru159 { get; set; }
        [DisplayName("Sırf kendinizi gösterme için toplantılarda söz alır mısınız?")]
        public int Soru160 { get; set; }
        [DisplayName("Okula ya da işe belli saatlerde gitmekten ve yine belli saatlerde eve dönmekten hoşlanır mısınız?")]
        public int Soru161 { get; set; }
        [DisplayName("Yeni şeyleri merak eder ve onları denemeye girişir misiniz?")]
        public int Soru162 { get; set; }
        [DisplayName("Kazancı az da olsa işsiz kalma tehlikesi olmayan bir mesleği tercih eder misiniz?")]
        public int Soru163 { get; set; }
        [DisplayName("Grup çalışmalarında ya da oyunlarında başkalarının görüş ve kararına güvenir misiniz?")]
        public int Soru164 { get; set; }
        [DisplayName("Bir tartışmada çok değişik ve ilginç fikirler ileri sürer misiniz?")]
        public int Soru165 { get; set; }
        [DisplayName("“Azıcık aşım kaygısız başım” özdeyişini ilke olarak benimser misiniz?")]
        public int Soru166 { get; set; }
        [DisplayName("Yetenekli insanların bir yer edinmek için yarıştığı bir ortamda çalışmak ister misiniz?")]
        public int Soru167 { get; set; }
        [DisplayName("Yüksele bilmeniz ve adınızı duyabilmeniz için öncelikle iyi bir kazanç elde etmeniz gerektiğini düşünür müsünüz?")]
        public int Soru168 { get; set; }
        [DisplayName("Tanınmış kimse olmak sizin için çok önemli midir?")]
        public int Soru169 { get; set; }
        [DisplayName("Daima kendinizi aşmak, yaptığınız bir işi bir öncekinden daha iyi yapmak için çaba harcar mısınız?")]
        public int Soru170 { get; set; }
        [DisplayName("Sizden daha büyük ve tecrübeli insanların görüşlerini almaya önem verir misiniz?")]
        public int Soru171 { get; set; }
        [DisplayName("Toplumda iyi bir yer edinebilmek için her fırsattan yararlanmaya çalışır mısınız?")]
        public int Soru172 { get; set; }
        [DisplayName("Hep aynı şekilde yapılan işler sizi sıkar mı?")]
        public int Soru173 { get; set; }
        [DisplayName("Bir insanın bütün isteklerini para ile edilebileceğine inanır mısınız?")]
        public int Soru174 { get; set; }
        [DisplayName("Gruplara önderlik, toplantılara başkanlık eder misiniz?")]
        public int Soru175 { get; set; }
        [DisplayName("Başkaları kadar iyi yapamadığınız bir işi bırakıp başka işlere yönelmektense, onun üzerine düşüp başarıncaya kadar uğraşır mısınız?")]
        public int Soru176 { get; set; }
        [DisplayName("Girdiğiniz il işte emekli oluncaya kadar çalışmayı düşünür müsünüz?")]
        public int Soru177 { get; set; }
        [DisplayName("Yarışmaların insanlarda yaratıcı güçleri harekete geçirdiğine inanır mısınız?")]
        public int Soru178 { get; set; }
        [DisplayName("Kazanç ve başarının, tehlikeyi göze alabilen insanların hakkı olduğuna inanır mısınız?")]
        public int Soru179 { get; set; }
        [DisplayName("Bir girişimde bulunmadan önce sonucun iyi olacağı yolunda kesin güvence arar mısınız?")]
        public int Soru180 { get; set; }
        [DisplayName("Gireceğiniz mesleğin, adınızı duyurmanıza olanak verecek bir meslek olmasına çok önem verir misiniz?")]
        public int Soru181 { get; set; }
        [DisplayName("Bir kimsenin çevresinde saygın kazanmasında kazancının önemli bir faktör olduğunu inanır mısınız?")]
        public int Soru182 { get; set; }
        [DisplayName("Bulunduğunuz sosyal ve ekonomik durumdan daha iyi bir duruma geçmek sizin için önemli midir?")]
        public int Soru183 { get; set; }
        [DisplayName("Bir iş yaparken çevrenizde danışabileceğiniz ve yardım alabileceğiniz insanlar olmasını ister misiniz?")]
        public int Soru184 { get; set; }
        [DisplayName("Zeki, bilgili ve üstün nitelikli kimselerle arkadaşlık ederek gelişeceğinize inanır mısınız?")]
        public int Soru185 { get; set; }
        [DisplayName("İhtiyaçlarınızı sınırlı tutarak kendinize yetecek düzeyde bir gelirle mutlu olabileceğinize inanır mısınız?")]
        public int Soru186 { get; set; }
        [DisplayName("Seçtiğiniz meslekte gelişmek ve ilerlemek sizce önemli midir?")]
        public int Soru187 { get; set; }
        [DisplayName("Günlerinizin birbirine benzemesi sizi rahatsız eder mi?")]
        public int Soru188 { get; set; }
        [DisplayName("Her işi ciddiye alır mısınız?")]
        public int Soru189 { get; set; }
        [DisplayName("Seçeceğiniz mesleğin iyi gelir sağlayan bir meslek olması sizce önemli midir?")]
        public int Soru190 { get; set; }
        [DisplayName("Belli bir amacı gerçekleştirmek için insanları bir araya getirebilir misiniz?")]
        public int Soru191 { get; set; }
        [DisplayName("İnsanların görev ve sorumluluklarını belirleyip çalışmalarını denetleyebilir misiniz?")]
        public int Soru192 { get; set; }
        [DisplayName("Yaptığınız işleri başkalarınınki ile karşılaştırır, eksiklerinizi gidererek herkesten daha iyi işler yapmaya çalışır mısınız?")]
        public int Soru193 { get; set; }
        [DisplayName("Grup içinde en son kararı veren kişi olabiliyor musunuz?")]
        public int Soru194 { get; set; }
        [DisplayName("Kazancı yüksek mesleklerin aynı zamanda itibarlı meslekler olduklarını düşünür müsünüz?")]
        public int Soru195 { get; set; }
        [DisplayName("Çok para kazanmak, zengin olmak sizin için hayatta önemli bir hedef midir?")]
        public int Soru196 { get; set; }
        [DisplayName("Değişik yerlerde yemek, daha önce hiç yemediğiniz yemekleri denemek ister misiniz?")]
        public int Soru197 { get; set; }
        [DisplayName("Gelişmenizin ve ilerlemenizin, yeteneklerine uygun bir mesleğe girmekle mümkün olabileceği görüşünde misiniz?")]
        public int Soru198 { get; set; }
        [DisplayName("Önemli sorumluluklar gerektiren görevleri istekle üstlenir misiniz?")]
        public int Soru199 { get; set; }
        [DisplayName("Grup çalışmalarında ya da oyunlarında sizin görüş ve kararınızın uygulanması sizce önemli midir?")]
        public int Soru200 { get; set; }
        [DisplayName("Yeni şeyleri denemekle gelişeceğinize inanır mısınız?")]
        public int Soru201 { get; set; }
        [DisplayName("Bir iş yerinde karar veren ve sorumluluk taşıyan bir kişi olmak ister misiniz?")]
        public int Soru202 { get; set; }
        [DisplayName("Nükte, espri yapar mısınız?")]
        public int Soru203 { get; set; }
        [DisplayName("Hangi alanlarda yetenekli olduğunuzu düşünür müsünüz?")]
        public int Soru204 { get; set; }
        [DisplayName("Yeni insanlar tanımaktan hoşlanır mısınız?")]
        public int Soru205 { get; set; }
        [DisplayName("Konuşurken çevrenizdeki insanların ilgisini çekebilir, görüşlerinizi ve kararınızı onlara kabul ettirebilir misiniz?")]
        public int Soru206 { get; set; }
        [DisplayName("Yaşama biçiminizde zaman zaman değişiklik yapabilme olanakları arar mısınız?")]
        public int Soru207 { get; set; }
        [DisplayName("Daha çok gelir elde etme umudu ile sık sık iş değiştirmeyi göze alır mısınız?")]
        public int Soru208 { get; set; }
        [DisplayName("Mesleğinizin ilginç ve hareketli bir yaşam sağlayan bir meslek olması sizce önemli midir?")]
        public int Soru209 { get; set; }
        [DisplayName("Her zaman belli işleri yapmak, belli yerlere gitmek sizi sıkar mı?")]
        public int Soru210 { get; set; }
        [DisplayName("Olur olmaz şeyler için kaygılanır ve üzülür müsünüz?")]
        public int Soru211 { get; set; }
        [DisplayName("Çevrenizde daima yenilikler getiren yaratıcı bir kişi olarak tanınır mısınız?")]
        public int Soru212 { get; set; }
        [DisplayName("Hangi alanlarda daha çok kazanç elde edebileceğinizi araştırır mısınız?")]
        public int Soru213 { get; set; }
        [DisplayName("Mesleğinizde ilerlemek, varabileceğiniz en son noktaya erişmek için bütün gücünüzle çalışmayı planlıyor musunuz? ")]
        public int Soru214 { get; set; }
        [DisplayName("Mesleğinizde ilerlemek, varabileceğiniz en son noktaya erişmek için bütün gücünüzle çalışmayı planlıyor musunuz?")]
        public int Soru215 { get; set; }
        [DisplayName("Daima başka insanlardan daha iyi olmak için çalışıyor musunuz?")]
        public int Soru216 { get; set; }
        [DisplayName("Üzerinize aldığınız bir işi dikkatle ve titizlikle yapmaya çalışır mısınız?")]
        public int Soru217 { get; set; }
        [DisplayName("Planlı ve düzenli bir yaşam sürmekle mutlu olabileceğinize inanır mısınız?")]
        public int Soru218 { get; set; }
        [DisplayName("Bir yarışmayı kaybedince, kendinizi geliştirip yeni bir yarışmaya girer misiniz?")]
        public int Soru219 { get; set; }
        [DisplayName("Toplumda adınızı, duyurmak ve itibarlı bir yer edinmek izin her fırsattan yararlanmaya çalışır mısınız?")]
        public int Soru220 { get; set; }
        [DisplayName("Bir mesleği incelerken öncelikle kazanç durumu hakkında bilgi edinmeye önem verir misiniz?")]
        public int Soru221 { get; set; }
        [DisplayName("Hayatta her öğrenilen becerinin, hemen değilse bile, günün birinde kişinin meslek başarısını arttıracağınıza inanır mısınız?")]
        public int Soru222 { get; set; }
        [DisplayName("Yüksek mevki sahibi kimselerin yaşama biçimlerini ve değerlerini benimsemeye çalışır mısınız?")]
        public int Soru223 { get; set; }
        [DisplayName("Vaktinizi boş geçirmemeye, yeteneklerinizi geliştirici her türlü öğrenme fırsatını değerlendirmeye çalışır mısınız?")]
        public int Soru224 { get; set; }
        [DisplayName("Toplumsal düzeyi ne olursa olsun, yaptığınız işte usta bir kişi olmak sizin için önemli midir?")]
        public int Soru225 { get; set; }
        [DisplayName("Çalışırken sorumluluğu iş arkadaşları ile paylaşmak size rahatlık verir mi?")]
        public int Soru226 { get; set; }
        [DisplayName("Toplumda itibar görebilmeniz için itibarlı bir meslek sahibi olmanız gerektiğine inanır mısınız?")]
        public int Soru227 { get; set; }
        [DisplayName("Piyangodan yüklü bir para çıksa yine de bir meslek edinmek için uğraşır mısınız?")]
        public int Soru228 { get; set; }
        [DisplayName("Yetenekli olduğunuz bir alanda, işleri başkalarının söylediği biçimde ya da alışıldığı gibi yapmak zorunda olmak sizi sıkar mı?")]
        public int Soru229 { get; set; }
        [DisplayName("Size göre meslek, yetenekleri kullanma yolu mudur?")]
        public int Soru230 { get; set; }

    }
}