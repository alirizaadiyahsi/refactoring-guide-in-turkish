# TÜRKÇE REFACTORING KILAVUZU

## ÖNSÖZ

Bu dökümanın, bir makale olarak değilde GitHub'da olmasının sebebi, herkesin katkılarına açık bir şekilde sürekli güncel bir kılavuz hazırlamak.

Bazı kelimeler Türkçeye çevrilmedi. Bunun sebebi, birçok kelime artık, o kalıp içinde daha anlamlı oluyor. Örneğin, Refactoring, Exract Method, Primitive Obsession vs. 

## İÇİNDEKİLER

- [Refactoring Nedir?](#refactoring-nedir)
  - [Temiz Kod Nedir?](#temiz-kod-nedir)
  - [Teknik Borç Nedir?](#teknik-borç-nedir)
  - [Refactoring Ne Zaman Yapılmalı?](#refactoring-ne-zaman-yapılmalı)
  - [Refactoring Nasıl Yapılır?](#refactoring-nasıl-yapılır)
- [Koddan Kötü Kokular Geliyor](#koddan-kötü-kokular-geliyor)
  - [Uzun Metotlar](#uzun-metotlar)
  - [Büyük Sınıflar](#büyük-sınıflar)
  - [Primitive Obsession](#primitive-obsession)
  - [Çok Fazla Parametre](#çok-fazla-parametre)

## REFACTORING NEDİR?

Refactoring, kodun işlevselliğini değiştirmeden, kodun kalitesini artırma, temiz bir hale ve kolay bir tasarıma dönüştürme sürecidir. Refactoring kavramını anlamak için öncelikle temiz ve basit kod nedir, temiz kodu engelleyen, kötü kod yazmaya iten sebepler nelerdir bir diğer deyişle teknik borç nedir teknik borca iten sebepler nelerdir, onu anlamaya çalışalım.

### Temiz Kod Nedir?

#### Temiz kod diğer geliştiriciler için gayet açık ve anlaşılabilirdir. 

Değişken isimlendirmeleri, sınıfların ve metotların uzunlukları ve karmaşıklıkları vs. gibi kodun okunmasını, anlaşılmasını ve bakımını zorlaştıran şeylerin olmaması.

#### Temiz kod, kod tekrarları içermez.

Kod tekrarı, her defasında, aynı değişiklikleri farklı yerlerde yapmaya sebep olur. Her defasında, bir değişiklik yapıldığında, başka nerelerin değişeceğini akılda tutmak gerekir. Kodun anlaşılmasındaki yükü artırır ve süreçleri uzatır.

#### Temiz kodda gereğinden fazla satır/sınıf/metot olmaz.

Az kod, daha az akılda tutulması gereken şey, daha az bakım yapılması, daha az hata demektir. Olabildiğince kısa ve basit kod her zaman temiz koddur.

#### Temiz kodun bakım maliyeti düşüktür.

Temiz kod bakımı kolaylaştırır, hız kazandırır ve bakım maliyetini düşürür.

### Teknik Borç Nedir?

Hiç kimse, projeye zarar vermek için bilerek kötü kod yazmaz. Herkes elinden gelenin en iyisini yapmak ister. Kötü kod yazmaya iten sebepler vardır. Kötü yazılan kod da, ilerde başımıza dert açabilir.

Teknik borcu anlatmak için, bankadan çekilen kredi örnek verilir. Acil ödemeniz gereken bir borç için, günü kurtarmak adına çekilen kredi, daha sonra daha fazla borç olarak tekrar karşımıza çıkar. Çekilen tutar tekrar faizi ile geri ödenir. 

Aynı şekilde, daha hızlı geliştirmek adına; mesela test yazmadan, geliştirilen her özellik, gün geçtikçe bakım maliyetini artırarak, geliştirme hızını da düşürür, ta ki teknik borcu ödeyene kadar.

Peki teknik borca, kötü kod yazmaya iten sebepler nelerdir?

#### Ticari kaygılar

Bazen iş koşulları, tamamlanmadan önce özellikleri kullanıma sunmaya zorlayabilir. Bu durumda, projenin bitmemiş bölümlerini gizlemek için kodda fazladan (aslında kodun parçası olmayan) satırlar olabilir.

#### Teknik borcun sonuçlarının anlaşılmaması

İşverenler/yöneticiler, geride teknik borç biriktirdikçe, maliyetin katlanarak arttığını anlamayabilirler. Bundan dolayıda, ekibin refactoring için zaman ayırmasını, vakit kaybı olarak görürler ve değer vermezler.


#### Ekip üyeleri arasındaki iletişim eksikliği 

İletişim eksikliğinden dolayı bilgi, ekip üyeleri arasında sağlıklı dağılmaz veya tecrübeli birisi bilgiyi tecrübesiz olana yanlış aktarabilir. Bundan dolayıda ekip elindeki güncel olmayan, eksik veya yanlış anlaşılmış bilgi ile geliştirme yapabilir. 

#### Uzun süre farklı dallarda(branch) çalışılması

Teknik borcun birikmesine ve birleştirme işleminde daha da artmasına sebep olur. Toplam teknik borç, ayrı ayrı biriken teknik borç toplamından daha büyük olur.

#### Gecikmeli refactoring 

Refactoring gerekli durumlarda, refactoring ertelenirse, düzenlenmesi gereken bu parçaya bağımlı yeni yazılan her kod, eski düzene göre yazılacağından, teknik borç her yeni yazılan kod için de artar. Oysa anında müdahale edilse, arkasından gelen kodlar için de aynı düzenleme gerekmeyecek.

#### Beceriksizlik & tecrübesizlik

Bazen sadece tecrübesizlikten veya beceriksizlikten kötü kod yazarak, teknik borç biriktiririz.

### Refactoring Ne Zaman Yapılmalı?

#### Üç kural

1. İlk defa bir şey yapıyorsan, sadece yap.
2. İkinci defa aynı şeyi yapıyorsan, tekrara düşmekten çekin ama yinede bir şekilde yap.
3. Üçüncü defa aynı şeyi yapıyorsan, refactor et.

#### Özellik ekleme

Refactoring, başkalarının kodlarını anlamayı kolaylaştırır. Yeni özellik eklemek için kodun iyi anlaşılması gereklidir. Kod ne kadar temiz olursa o kadar anlaşılır olur. Dolayısıyle yeni özellik eklemeden önce kodlar refactor edilebilir.

#### Hata düzeltme

Yine hata bulmak için öncelikle kodun iyi anlaşılması lazımdır. Daha iyi anlamak için kodu refactor ederiz. Refactor işlemi sırasında, çoğunlukla hata bulunur. 

#### Kod inceleme (code review)

Kod inceleme, hem kodu yazan hem de inceleyen için en faydalı iştir. Kod incleme yaparken, hata bulmak daha kolay ve hızlı olur. İlerde yapılabilecek daha büyük hatalar için de, önceden bilgi sahibi olmayı sağlar.

### Refactoring Nasıl Yapılır?

Refactoring kodun normal çalışmasında hiçbir değişiklik yapmadan, kodun daha iyi bir hale gelmesi için yapılan değişiklikler şeklinde olmalıdır.

#### Kod daha temiz hale gelmeli

Refactoring işleminden sonra kodlar hala temiz ve anlaşılır değilse, harcadığımız zaman boşa gitmiş demektir. Bu durumda neden böyle olduğunu anlamaya çalışmak lazım. Refactoring yaparken genelde; küçük değişiklikler yaparken, birden tek seferde çok büyük bir değişiklikler silsilesi içine girince ve üstüne bir de zaman kısıtı varsa işlerin karışmasına sebep olabilir. Bundan dolayı da refactoring sonucunda ortaya çıkan kod pek de temiz bir kod olmaz.

Ancak bazı kod altyapısı o kadar kötüdür ki, ne yaparsanız yapın iyileştirilemeyebilir. İşte bu durumda, kodun yeniden yazılması düşünülebilir. Tabi bunu yapacaksak, kesinlikle ilgili yerlerin testlerinin yazılmış olması şart. Ayrıca biraz zaman ayırmak da gerekli.

#### Refactoring sırasında yeni bir özellik/fonksiyonelite eklenmemeli

Yeni özellik eklemek için yazılan kodlar ile refactoring için yazılan kodlar farklı commit'lerde olmalıdır. Refactoring kodun işlevini değiştirmez, sadece daha iyi hale getirir.

#### Tüm testler refactoring işleminden sonra başarılı olmalı

Testleri olmayan kodları refactor etmek, refactoring sürecindeki en tehlikeli kısımdır. Refactoring yaptıktan sonra 2 durumda testler başarısız olabilir.

- **Refactoring sırasında hata yaptın ve çokta önemli değil:** Devam et ve hatayı düzelt.
- **Testler çok alt seviye kodları test ediyordur. Örneğin, bir sınıfın private metodunu test ediyordur:** Bu durumda, sıkıntı testlerdedir. Dolayısıyla testleri de refactor edebiliriz veya yüksek seviye kodları test eden yeni testler yazabiliriz. Tabi bunun en ideal çözümü, [BDD-style](https://en.wikipedia.org/wiki/Behavior-driven_development) test yazmakdır.

## KODDAN KÖTÜ KOKULAR GELİYOR

Refactoring yapılacak kod aslında kendisi alarm verir. Koddaki kötü kokular, refactoring için ipuçları içerir. Bu kötü kokuların neler olduğunu bilirsek, refactoring yapılacak kodları daha iyi ayırt edebiliriz.

### Uzun Metotlar

#### Problem

Bir metot çok fazla satırdan oluşuyorsa o metotta sorunlar olabilir. Genel olarak 10-15 satırdan fazla uzun metotlar olunca, metodun uzunluğunu sorgulamaya başlayabiliriz.

#### Sebep

Yazılımcı için kod yazmak, kod okumaktan daha kolaydır. Bundan dolayı metotlara sürekli gerekli olan kodlar eklenir ama kullanılmayan satırlar silinmez. Her gelen bir şey ekler. Böylece metodun uzunluğu gittikçe artar, okunamaz ve bakım yapılamaz hale gelir. 

Psikolojik olarak, yeni bir metot oluşturmak, var olana ekleme yapmaktan daha kolay gelebilir. İki satır kod için, yeni bir metoda ihtiyaç yok diye düşünebiliriz. Her defasında bu düşüncüyle eklenen her satırdan sonra, metot adım adım karmaşık bir spagetti koda dönüşür.

#### Çözüm

Eğer metot içinde, yorum yazma gereksinimi olan satırlar varsa, bu satırların ayrı bir metoda alınması gerekebilir. Tek satırı bile açıklamaya ihtiyaç duyuyorsanız, ayırmanız gerekir. Ayrılan yeni metodun adı da, metodun ne iş yaptığını tanımlayıcı olursa, kimse kodun ne iş yaptığını anlamak için kodu okumak zorunda kalmaz. Çözüm için aşağıdaki refactoring kuralları uygulanabilir.

- Metot uzunluğunu azaltmak için: [Extract Method](#extract-method) 
- Değişkenler ve parametreler yeni metoda almayı engelliyorsa: [Temp with Query](#temp-with-query), [Introduce Parameter Object](#introduce-parameter-object), [Preserve Whole Object](#preserve-whole-object).
- İlk 2 yöntem de yardımcı olmuyorsa: [Replace Method with Method Object](#replace-method-with-method-object)
- Kod içerisindeki koşullu ifadeler ve döngüler metodun ayrılması için ipucu verirler. Koşullu ifadeler için: [Decompose Conditional](#decompose-conditional).

#### Sonuç

- Tüm OOP dillerde en uzun yaşayan metotlar/sınıflar en kısa olanlarıdır. Metot ne kadar uzun olursa, anlamak ve bakım yapmak da o kadar zorlaşır.
- Uzun kodlar içinde, tekrarlanan kodlar birikmiş olabilir. 

#### Performans

Akıllara gelen sorulardan birisi şu; metot sayısı arttıkça performans kötü etkilenir mi? Aslında neredeyse tüm durumlarda, etki o kadar önemsiz ki, sağladığı fayda yanında bu etkinin bir önemi yok.

Ayrıca temiz ve bakımı kolay bir kodu istediğimiz gibi kolayca refactor edebilir, yeniden tasarlayabilir ve gerçekten performanslı bir hale daha kolay getirebiliriz. 

### Büyük Sınıflar

#### Problem

Çok fazla satır, alan ve metot içeren sınıflar.

#### Sebep

Sınıflar en başta genelde küçük başlar. Ancak zamanla, program büyüdükçe şişerler.

Uzun metotlarda olduğu gibi, programcılar genellikle mevcut bir sınıfa, yeni bir özellik/satır eklemenin, yeni bir sınıf oluşturmaya göre daha kolay olduğunu düşünür.

#### Çözüm

- Eğer sınıfın davranışının bir parçası ayrılabiliyorsa: [Extract Class](#extract-class)
- Eğer sınıfın bir parçası, başka bir şekilde yazılabiliyorsa veya nadir durumlarda kullanılabilirse: [Extract Subclass](#extract-subclass)
- İstemcinin kullanabileceği, sınıfın yaptığı işlerin bir listesini tutmak için: [Extract Interface](#extract-interface)
- Grafik arayüzünden büyük bir sınıf sorumluysa, verilerinin ve davranışlarının bir kısmını ayrı bir domain object nesnesine taşımayı deneyebilirsiniz. Bunu yaparken, bazı verilerin kopyalarını iki yerde saklamak ve verileri tutarlı tutmak gerekebilir. Bunun için: [Duplicate Observed Data](#duplicate-observed-data)

#### Sonuç

- Bu sınıfların yeniden yapılandırılması, geliştiricilerin bir sınıf için çok sayıda şeyi hatırlama zorunluluğundan kurtarır.
- Çoğu durumda, büyük sınıfları parçalara bölmek, kod ve işlevselliklerin tekrarlanmasını önler.

### Primitive Obsession

#### Problem

- Küçük nesneler (range, currency, special strings) yerine primitif tipler kullanma.
- Kodun içinde sabit değerlerde bilgi tutmak. (Örneğin; admin yetkisi için `USER_ADMIN_ROLE = 1` şeklinde bir tanımlama yapmak)
- Her bir alanın adının, dizi içinde sabit olarak tutulması. (Örneğin; `dizi["istanbul", "34"]`)

#### Sebep

Diğer hatalarda olduğu gibi, Primitive Obsession hatası, zayıf olduğumuz anlarda ortaya çıkar. Sadece 1 tane değişken için, sınıf oluşturmak zor gelir ve bu 1 veriyi tutmak için primitif tipte bir değişken tanımlanır. Yeni bir alan lazım olduğunda her defasında bu şekilde eklenir ve sınıflar/metotlar gereksiz olarak şişer.

Bazen de sabit değerler, kod içinde kullanılacak olan bir entity hakkında bilgi tutmak için kullanılır. Ayrı bir tip tanımlaması yapmak yerine, sınıf içinde sabit değerler bu bilgiyi tutar. Bunun sebebi ise, kod içerisinde bu değerler kullanılırken daha anlaşılır olmasını sağlamak. Örneğin; `if(userRole == AppConsts.USER_ADMIN_ROLE)`. Bu kullanım çok yaygındır.

Bir diğer hata ise, sınıfın her bir alanının tutması gereken veri, kolay olsun diye bir diziye atılır. 

#### Çözüm

- Çok çeşitli primitif tipler varsa, bu verileri ilişkilerine göre gruplayıp, kendi sınıflarına taşımak: [Replace Data Value with Object](#replace-data-value-with-object)
- Gruplanabilecek primitif tipler, eğer metot parametresi olarak kullanılıyorsa: [Introduce Parameter Object](#introduce-parameter-object), [Preserve Whole Object](#preserve-whole-object)
- Kendi başına bir nesne olabilecek, veri tutan bir değişken için: [Replace Type Code with Class](#replace-type-code-with-class), [Replace Type Code with Subclasses](#replace-type-code-with-subclasses), [Replace Type Code with State/Strategy](#replace-type-code-with-state/strategy)
- Bir nesnenin alanlarını tutan dizi varsa: [Replace Array with Object](#replace-array-with-object)

#### Sonuç

- Primitif tipler yerine nesnelerin kullanılması, kodu daha esnek yapar.
- Daha anlaşılabilir ve organizasyonu daha iyi bir kod yapısı sağlar. Veri üzerindeki her işlemi temsil eden alanlar aynı yerde ve düzenli olur. Diziler içindeki verilerin sürekli ne anlama geldiğini tahmin etmekten kurtarır.
- Kod tekrarlarını(code duplication) keşfetmek daha kolay olur. 

### Çok Fazla Parametre

#### Problem

Bir metodun 3,4 veya daha fazla parametre alması.

#### Sebep

Birkaç farklı tipte algoritmanın bir metotda birleşmesi sonucunda, parametreler çoğalabilir. Metodun içindeki algoritmanın ne yapıyor olduğuna dair bilgi veren kontrol parametreleri kullanılıyor olabilir. Hangi algoritma hangi adımlarla çalışıyor diye çok ayrım yapınca, parametre sayısı artabilir.

Birbirinden bağımsız sınıflar oluşturmak istemenin yan etkisi olarak da fazla parametre alan metodlar oluşabilir. Örneğin; bir sınıf içinde, bir nesne oluşturan metodlar kullanılırlar. Oluşan bu nesneler de başka bir metoda parametre olarak verilir. Böylece ana sınıf, nesneler arasındaki ilişkiyi bilmez ve bağımlılık azalır. Ama bu şekilde bir çalışma en son parametre alan metodun parametre sayısını artırır.

#### Çözüm

- Bazı parametreler, metotların sonucunda gelen nesneler ise: [Replace Parameter with Method Call](#replace-parameter-with-method-call)
- Başka bir nesneden alınan bir veri grubunu parametre olarak göndermek yerine, nesneyi kendisini metoda parametre olarak geçmek: [Preserve Whole Object](#preserve-whole-object)
- Birden çok ilişkisiz parametre varsa bunları tek bir nesne içinde toplayıp, parametre olarak geçme: [Introduce Parameter Object](#introduce-parameter-object)

#### Sonuç

- Daha okunabilir ve kısa kodlar.
- Varsa daha önceden farkedilmemiş olan, kod tekrarı farkedilebilir.

#### Ne zaman göz ardı edilebilir?

Sınıflar arasında gereksiz bağımlılık oluşturabilecek durumlarda parametrelerde kurtulmak iyi bir yöntem olmayabilir.

### Veri Kümeleri

#### Problem

Ortak nesneye sahip olabilecek parametre listelerinin parametre olarak kullanılması. Müşteri bilgileri, adres bilgileri, veritabanı bağlantı bilgileri gibi. Bunların hepsi ayrı nesne olarak tanımlanabilir. 

#### Sebep

Genelde zayıf kod tasarımı veya "kopyala-yağıştır programcılığı" ile ortaya çıkar.

#### Çözüm

- Parametreler, bir sınıfın alanları olabilecek şekilde gruplanabiliyorsa: [Extract Class](#extract-class)
- Aynı veri kümeleri, parametre olarak geçiliyorsa (örneğin; startDate, endDate): [Introduce Parameter Object](#introduce-parameter-object)
- Metot içindeki bazı veriler, başka metoda parametre olarak verilecekse, onun yerine komple nesneyi parametre vermek: [Preserve Whole Object](#preserve-whole-object)


#### Sonuç

Kodun anlaşılabilirliğini ve organizyonunun kalitesini artırır. Parametreler dağınık olarak, etrafta duracağına, bir sınıf içinde toplanmış olur. Kod tekrarı engellenir.

Kodu kısaltır.

#### Ne zaman göz ardı edilebilir?

Eğer sınıflar arasında gereksiz bir bağımlılık oluşturacaksa göz ardı edilebilir.

---

## KAYNAKLAR

**NOT**: Yararlanılan kaynaklar sürekli eklenecek. 

- https://refactoring.guru/
- http://www.yilmazcihan.com/yazilim-gelistirmede-teknik-borc/
- https://softwareengineering.stackexchange.com/questions/365017/when-is-primitive-obsession-not-a-code-smell
