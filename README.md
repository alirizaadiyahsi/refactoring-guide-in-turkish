# TÜRKÇE REFACTORING KILAVUZU

## ÖNSÖZ

Bu dokümanın bir makale olarak değil de GitHub'da olmasının sebebi, herkesin katkılarına açık bir şekilde sürekli güncel bir kılavuz hazırlamak.

Bazı kelimeler Türkçeye çevrilmedi. Bunun sebebi, birçok kelime artık o kalıp içinde daha anlamlı oluyor. Örneğin; Refactoring, Extract Method, Primitive Obsession vs. 

## İÇİNDEKİLER

- [Refactoring Nedir?](#refactoring-nedir)
  - [Temiz Kod Nedir?](#temiz-kod-nedir)
  - [Teknik Borç Nedir?](#teknik-borç-nedir)
  - [Refactoring Ne Zaman Yapılmalı?](#refactoring-ne-zaman-yapılmalı)
  - [Refactoring Nasıl Yapılır?](#refactoring-nasıl-yapılır)
- [Koddan Kötü Kokular Geliyor](#koddan-kötü-kokular-geliyor)
  - [Long Method](#long-method)
  - [Large Class](#large-class)
  - [Primitive Obsession](#primitive-obsession)
  - [Long Parameter List](#long-parameter-list)
  - [Data Clumps](#data-clumps)
  - [Switch Statements](#switch-statements)
  - [Temporary Field](#temporary-field)
  - [Refused Bequest](#refused-bequest)
  - [Alternative Classes with Different Interfaces](#alternative-classes-with-different-interfaces)
  - [Divergent Change](#divergent-change)
  - [Shotgun Surgery](#shotgun-surgery)
  - [Parallel Inheritance Hierarchies](#parallel-inheritance-hierarchies)
  - [Comments](#comments)
  - [Duplicate Code](#duplicate-code)
  - [Lazy Class](#lazy-class)
  - [Data Class](#data-class)
  - [Dead Code](#dead-code)
  - [Speculative Generality](#speculative-generality)
  - [Feature Envy](#feature-envy)
  - [Inappropriate Intimacy](#inappropriate-intimacy)
  - [Message Chains](#message-chains)
  - [Middle Man](#middle-man)
  - [Incomplete Library Class](#incomplete-library-class)
- [Refactoring Teknikleri](#refactoring-teknikleri)
  - [Extract Method](#extract-method)
  - [Inline Method](#inline-method)
  - [Extract Variable](#extract-variable)
  - [Inline Temp](#inline-temp)
- [Kaynaklar](#kaynaklar)

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

Teknik borcu anlatmak için, bankadan çekilen kredi örnek verilir. Acil ödemeniz gereken bir borç için, günü kurtarmak adına çekilen kredi, daha sonra daha fazla borç olarak tekrar karşımıza çıkar. Çekilen tutar tekrar faiziyle geri ödenir. 

Aynı şekilde, daha hızlı geliştirmek adına; mesela test yazmadan, geliştirilen her özellik, gün geçtikçe bakım maliyetini artırarak, geliştirme hızını da düşürür, ta ki teknik borcu ödeyene kadar.

Peki teknik borca, kötü kod yazmaya iten sebepler nelerdir?

#### Ticari kaygılar

Bazen iş koşulları, tamamlanmadan önce özellikleri kullanıma sunmaya zorlayabilir. Bu durumda, projenin bitmemiş bölümlerini gizlemek için kodda fazladan (aslında kodun parçası olmayan) satırlar olabilir.

#### Teknik borcun sonuçlarının anlaşılmaması

İşverenler/yöneticiler, geride teknik borç biriktirdikçe, maliyetin katlanarak arttığını anlamayabilirler. Bundan dolayı da, ekibin refactoring için zaman ayırmasını, vakit kaybı olarak görürler ve değer vermezler.

#### Ekip üyeleri arasındaki iletişim eksikliği 

İletişim eksikliğinden dolayı bilgi, ekip üyeleri arasında sağlıklı dağılmaz veya tecrübeli birisi bilgiyi tecrübesiz olana yanlış aktarabilir. Bundan dolayı da ekip elindeki güncel olmayan, eksik veya yanlış anlaşılmış bilgiyle geliştirme yapabilir. 

#### Uzun süre farklı dallarda (branch) çalışılması

Teknik borcun birikmesine ve birleştirme işleminde daha da artmasına sebep olur. Toplam teknik borç, ayrı ayrı biriken teknik borç toplamından daha büyük olur.

#### Gecikmeli refactoring 

Refactoring gerekli durumlarda, refactoring ertelenirse, düzenlenmesi gereken bu parçaya bağımlı yeni yazılan her kod, eski düzene göre yazılacağından, teknik borç her yeni yazılan kod için de artar. Oysa anında müdahale edilse, arkasından gelen kodlar için de aynı düzenleme gerekmeyecek.

#### Beceriksizlik & tecrübesizlik

Bazen sadece tecrübesizlikten veya beceriksizlikten kötü kod yazarak, teknik borç biriktiririz.

### Refactoring Ne Zaman Yapılmalı?

#### Üç kural

1. İlk defa bir şey yapıyorsan, sadece yap.
2. İkinci defa aynı şeyi yapıyorsan, tekrara düşmekten çekin ama yine de bir şekilde yap.
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

Yeni özellik eklemek için yazılan kodlarla refactoring için yazılan kodlar farklı commit'lerde olmalıdır. Refactoring kodun işlevini değiştirmez, sadece daha iyi hale getirir.

#### Tüm testler refactoring işleminden sonra başarılı olmalı

Testleri olmayan kodları refactor etmek, refactoring sürecindeki en tehlikeli kısımdır. Refactoring yaptıktan sonra 2 durumda testler başarısız olabilir.

- **Refactoring sırasında hata yaptın ve çok da önemli değil:** Devam et ve hatayı düzelt.
- **Testler çok alt seviye kodları test ediyordur. Örneğin, bir sınıfın private metodunu test ediyordur:** Bu durumda, sıkıntı testlerdedir. Dolayısıyla testleri de refactor edebiliriz veya yüksek seviye kodları test eden yeni testler yazabiliriz. Tabi bunun en ideal çözümü, [BDD-style](https://en.wikipedia.org/wiki/Behavior-driven_development) test yazmakdır.

## KODDAN KÖTÜ KOKULAR GELİYOR

Refactoring yapılacak kod aslında kendisi alarm verir. Koddaki kötü kokular, refactoring için ipuçları içerir. Bu kötü kokuların neler olduğunu bilirsek, refactoring yapılacak kodları daha iyi ayırt edebiliriz.

### Long Method

#### Problem

Metodun gövdesinin gereksiz, aşırı, okunamayacak ve bakımı yapılamayacak derecede uzun olması.

#### Sebep

Yazılımcı her zaman kodu kendisi yazmak ister. Kendi yazmadığı kodlara güvenmez/güvenmek istemez. Bundan dolayıda kod yazmak, kod okumaktan kolay gelir yazılımcıya. Her yeni gelen yazılımcı, bir yandan okumadan kod ekleyip, bir yandan da kullanılmayan kodları silinmeyince, metot gittikçe şişer, okunamaz ve bakımı yapılamaz hale gelir. Okunamayan kod, sürekli yeni kodların eklenmesini tetikleyerek kısır döngü oluşturur.

İki satır kod için yeni bir metoda ihtiyaç yok diye düşünüp, tüm kodu var olan metotlara eklemek, her zaman yazılımcıya daha kolay gelir. Bu da kodu işin içinden çıkılmaz bir hale sokar.

#### Çözüm

Anlaşılması için illa açıklanması gereken her kod bloğu ayrı bir metoda taşınabilir. Kodların anlaşılması için taşınan metodun ismi, metodun ne yaptığına dair kesin bilgi vermelidir. Böylece metodu kullananlar, metodun ne yaptığını, içindeki kodları okumadan anlayabilir.

Kod içerisindeki koşullu ifadeler, döngüler her zaman, kodları farklı metoda taşımak için birer adaydır. Kullanılabilecek rafactoring teknikleri: [Extract Method](#extract-method), [Temp with Query](#temp-with-query), [Introduce Parameter Object](#introduce-parameter-object), [Preserve Whole Object](#preserve-whole-object), [Replace Method with Method Object](#replace-method-with-method-object) ve [Decompose Conditional](#decompose-conditional).

#### Sonuç

Sürekli büyüyen kodlar için, tekrar eden, aynı işi yapan, belki de yanlış çalışan kodlar olabilir. Bu kodlar içinde hata bulmak, tekrar eden kodları temizlemek ve bakım yapmak çok zor iştir. Bu kötü tasarımdan kurtulursak, tüm bu olumsuzluklardan da kurtuluruz.

#### Performans

Kodun daha anlaşılır, bakım yapılabilir ve daha az hataya açık olması, her zaman maliyeti düşürür ve geliştirme hızını artırır. Ayrıca daha iyi tasarlanmış bir kod, daha hızlı çalışır. Daha iyi tasarlanmış bir kodda gereksiz kodlarda olmaz. Yani aslında performansın dengelenmesinin yanında, fazladan geliştirme hızı ve maliyet düşüşü sağlamış oluruz.

### Large Class

#### Problem

Bir sınıfta gereğinden fazla alan, metot, özellik ve dolayısıyla fazla kod olması.

#### Sebep

Uzun metotlardaki gibi, uzun sınıfların oluşmasındaki en büyük sebep, kolay olmasından dolayı, kodu okumak yerine, direk koda ekleme yapmasıdır.

#### Çözüm

En iyi çözüm en başta sınıfı parçalara ayırmak. Mesela, GUI'nin kullandığı kısımlar ayrı bir sınıfa taşınabilir. Sınıf paralel veya hiyerarşik olarak ayrıştırılabilir. Aynı şekilde, sınıf içinde gruplanabilecek davranışlar, interface olarak da ayrıştırılabilir. 

Kullanılabilecek refactoring teknikleri: [Extract Class](#extract-class), [Extract Subclass](#extract-subclass), [Extract Interface](#extract-interface), [Duplicate Observed Data](#duplicate-observed-data).

#### Sonuç

Sınıfın daha düzenli, daha okunabilir ve daha kolay bakım yapılabilir bir hale gelmesiyle, yazılımcı sınıfın ne yaptığını, içinde neler olduğunu hatırlama zorunluluğundan da kurtulur. Kod daha fazla kontrol altında tutulabildiğinden, kod tekrarlarının da önüne geçilmiş olur.

### Primitive Obsession

#### Problem

Kod içerisinde primitif tiplere, işlerinin dışında sorumluluklar vermek. Örneğin; `range` diye bir nesne yerine, `start` ve `end` diye değişken kullanmak, `USER_ADMIN_ROLE = 1` şeklinde, kodun içinde sabit veriler tutmak veya `dizi["istanbul", "34"]` gibi bir dizi içinde, bir nesnenin her bir alanının tutacağı verileri tutmak.

#### Sebep

Biraz tembellikten, belki biraz da tecrübesizlikten, başta bir tane veri için, bir nesne oluşturmak yerine, kolay olan yolu yani değişken tanımlama yoluna gideriz. Benzer bir alan daha lazım olduğunda, kodu refactor edip nesneye çevirmek yerine, bu yeni alanı da, başka bir değişkene atarız. Her defasında bu hatayı yaptıkça, sınıflar/metotlar şişer.

Bir diğer hata da kullanımı kolay ve anlaşılır olan değişkenlerde veritabanına ait olabilecek veriler tutmak. En kötüsü ise, bir sınıfın her alanının, bir dizide veri olarak tutulması. Neyse oluşturmak o kadar zor gelirki, bir dizide bu nesnenin her alanı için bir veri tutulur. 

#### Çözüm

Çözüm basit: nesne oluşturmak. Gruplanabilecek olanlar bir nesne(sınıf) çatısı altında toplamalıyız. Sınıfın alanları olabilir, metodun parametreleri olabilir, kendi başına nesne olabilecek bir değişken olabilir veya zaten grup olan dizi elemanları olabilir; bunların hepsi ayrı bir nesne olabilir.

Kullanılabilecek refactoring teknikleri: [Replace Data Value with Object](#replace-data-value-with-object), [Introduce Parameter Object](#introduce-parameter-object), [Preserve Whole Object](#preserve-whole-object), [Replace Type Code with Class](#replace-type-code-with-class), [Replace Type Code with Subclasses](#replace-type-code-with-subclasses), [Replace Type Code with State/Strategy](#replace-type-code-with-state/strategy), [Replace Array with Object](#replace-array-with-object).

#### Sonuç

Kod daha düzenli, esnek, anlaşılır olur ve bu da kod tekrarının önüne geçer, bakım maliyetini düşürür. Çünkü artık dizi içindeki verilerin neyi ifade ettiğini anlamakla uğraşmayız, birbiri ile ilişkili verileri, tek bir yerden kontrol edebiliriz.

### Long Parameter List

#### Problem

Methodun çok fazla parametre alması.

#### Sebep

Metot değiştikçe yeni parametreler eklemek gerekebilir. Her yeni parametre ekledikten sonra, önlem alınmazsa parametreler gittikçe çoğalır veya metot kendi içinde sınıfın verilerini kullanmak yerine, onları parametre olarak alabilir. Bunun sebebi bağımlılığı azaltmak ama yine metodun parametreleri artmış olur. 

#### Çözüm

Metot aynı sınıf içindeki verileri parametre alıyorsa buna gerek yok. Parametre geçmek yerine, metot içinde bu veriler kullanılabilir. Bir sınıfın alanlarını tek tek parametre geçmek yerine, sınıfın kendisini parametre geçmek daha mantıklıdır. Diğer bir durum ise, ilişkili olabilecek parametreleri, bir nesneye çevirmek. Örneğin, `start` ve `end` parametrelerini `range` nesnesine çevirip, bunu parametre olarak geçebiliriz. 

Kullanılabilecek refactoring teknikleri: [Replace Parameter with Method Call](#replace-parameter-with-method-call), [Preserve Whole Object](#preserve-whole-object), [Introduce Parameter Object](#introduce-parameter-object).

#### Sonuç

Daha okunabilir, kısa, bakımı kolay kodlar. Daha okunabilir kod içerisinde, gereksiz kodl tekrarları da daha rahat farkedilir, dolayısıyla, kod tekrarlarından da kurtulunabilir.

#### Ne zaman göz ardı edilebilir?

Sınıflar arasında gereksiz bağımlılıklar oluşturabilecek her durumda göz ardı edilebilir.

### Data Clumps

#### Problem

Ortak bir sınıfta toplanabilecek değişkenlerin, tek tek parametre olarak kullanılması. Örneğin; Müşteri bilgileri, adres bilgileri, veritabanı bağlantı bilgileri gibi sınıflar oluşturabilir ve ortak parametreleri bu sınıfların özelliği haline getirebiliriz.

#### Sebep

Sebep `Long Parameter List` başlığındakilerle aynıdır.

#### Çözüm

Çözüm de yine `Long Parameter List` başlığındakiler ile benzerdir. Parametreleri gruplayıp, bir sınıfa taşıyıp, sınıfı parametre olarak geçmek.

Kullanılabilecek refactoring teknikler: [Extract Class](#extract-class), [Introduce Parameter Object](#introduce-parameter-object), [Preserve Whole Object](#preserve-whole-object).

#### Sonuç

Kodun anlaşılabilirliğini ve organizyonunun kalitesini artırır. Parametreler dağınık olarak, etrafta duracağına, bir sınıf içinde toplanmış olur. Kod tekrarı engellenir, dolayısıyla kod kısalır, okunabilirliği artar ve bakımı kolaylaşır.

#### Ne zaman göz ardı edilebilir?

Eğer sınıflar arasında gereksiz bir bağımlılık oluşturacaksa göz ardı edilebilir.

### Switch Statements

#### Problem

Okunması/anlaşılması ve bakımı zor `switch-case` veya gereksiz uzunluktaki `if-else` ifadeleri.

#### Sebep

`switch-case` ifadeleri çok fazla koşul gerektiği durumda birer ihtiyaç olarak kullanılırlar. Gereğinden fazla uzun `if-else` ifalerinin oluşması da yine, her yeni gelen koşul için, kodda hiç bir değişiklik yapmadan, uç uca eklenen koşullardan dolayı oluşur.  

#### Çözüm

`switch-case` veya uzun `if-else` olan yerde büyük ihtimalle bir sıkıntı vardır ve refactor edilmesi gerekebilir ve büyük olasılıkla `polymorphism` çözüm olabilir.

`switch-case` ifadeleri genellikle sınıfların daha iyi tasarlanması ile çözülebiliyor. Çözülemediği durumlar, koşul ifadelerinde metotların kullanıldığı durumlardır ve bunların çözümü de farklıdır.

Kullanılabilecek refactoring teknikler: [Extract Method](#extract-method), [Move Method](#move-method), [Replace Type Code with Subclasses](#replace-type-code-with-subclasses), [Replace Type Code with State/Strategy](#replace-type-code-with-state/strategy), [Replace Conditional with Polymorphism](#replace-conditional-with-polymorphism), [Replace Parameter with Explicit Methods](#replace-parameter-with-explicit-methods), [Introduce Null Object](#introduce-null-object).

#### Sonuç

Uygulamanın tasarımı daha iyi bir hal alır ve bakımı kolaylaşır. 

#### Ne zaman göz ardı edilebilir?

Aslında `switch-case` ifadeleri çok kullanışlıdır ve yerinde kullanıldığında, hız kazandırır. Eğer uygulanın içerisinde, yönetilemeyecek kadar çok dağılırsa ve kodun okunabilirliğini ve bakımını zorlaştıracaksa, `switch-case` ifadelerinden kaçınılmalıdır. Ama basit kullanımlarda hiçbir sakıncası yoktur. 

Ayrıca, `Factory design pattern` içinde de `switch-case` ifadeleri kullanmakta bir sakınca yoktur.

### Temporary Field

#### Problem

Geçici alanlar, sadece belirli koşullar altında değer alırlar. Bu koşullarında dışında, her zaman boş olurlar.

#### Sebep

Genellikle geçici alanlar, çok fazla girdisi olan bir algoritma içinde kullanılmak için oluşturulurlar. Dolayısıyla, metot için çok fazla parametre geçmek yerine, sınıfın içinde, veriyi tutması için bir alan oluşturulur. Bu alanlar sadece bu algoritma içinde kullanılır ve sonrasında artık anlamsızdır.

Bu tarz bir kodun anlaşılması zordur. Siz sürekli ilgili alanın bir veri tuttuğunu varsayarsınız; ama o tek bir algoritma dışında, her zaman boştur.

#### Çözüm

- Geçici alanı ve onunla ilişkili olan işlemleri farklı bir sınıfa taşıma: [Extract Class](#extract-class) veya [Replace Method with Method Object](#replace-method-with-method-bject)
- Geçici alanları kontrol etmek için: [Introduce Null Object](#introduce-null-object)

#### Sonuç

Daha iyi kod organizasyonu ve sadelik.

### Refused Bequest

#### Problem

Bir sınıf kalıtım aldığı sınıfın sadece birkaç metodunu veya özelliğini kullanıyorsa, sınıflar arasındaki hiyerarşi bozulur. İhtiyaç duyulmayan metotlar artık gereksiz hale gelir.

#### Sebep

Kodun yeniden kullanılması isteği, bazen gereksiz hiyerarşi kurmaya sebep olabilir. Ama kalıtım alınan sınıfla alan sınıf arasında çok farklılık vardır. Örneğin; `AnimalLegs` sınıfından türeyen, `DogLegs` ve `ChairLegs`.

#### Çözüm

- Kalıtım mantıklı değil ve kalıtım alan sınıfla üst sınıf arasında bir benzerlik yok ise: [Replace Inheritance with Delegation](#replace-inheritance-with-delegation)
- Eğer kalıtım yapmak uygunsa, kalıtım alan sınıf içindeki gereksiz alanlardan ve metotlardan kurtulun. Üst sınıfta olan ve alt sınıfta kullanılan metot ve alanları ayrı bir alt sınıfa taşıyın ve bu sınıftan kalıtım alın: [Extract Superclass](#extract-superclass)

#### Sonuç

Kodun okunabilirliğini ve organizasyonunu artırır. Artık, neden `Chair` sınıfının `Animal` sıfından türediğini merak etmeye gerek yok.

### Alternative Classes with Different Interfaces

#### Problem

İki farklı sınıfın, aynı işlemi farklı metot isimleriyle yapması.

#### Sebep

Sınıflardan birini oluşturan yazılımcının, muhtemelen aynı işlevi yapan başka bir sınıfın varlığından haberi yoktur.

#### Çözüm

- Tüm metotların tamamen aynı olması için: [Rename Method](#rename-method)
- Metodların imzasının ve uygulanmasının aynı olması için: [Move Method](#move-method), [Add Parameter](#add-parameter) ve [Parameterize Method](#parameterize-method)
- Sınıflardan sadece bir bölümünün benzer olduğu durumlarda: [Extract Superclass](#extract-superclass)
- Sınıflardan birisinin tüm işlemleri yaptığı ve diğerinin aslında gereksiz olduğunu düşündüğünüzde, gereksiz sınıfın silinmesi.

#### Sonuç

- Gereksiz kodların silinmesi.
- Kod daha temiz ve okunabilir olması.

#### Ne zaman göz ardı edilebilir?

Bazen sınıfları birleştirmek mümkün olmayabilir veya çok zor olabilir. Mesela, sınıflar farklı kütüphanelerde olabilir. Her kütüphanenin geliştirilmesi, versiyonlanması farklı yönetilir.

### Divergent Change

#### Problem

Bir sınıfta değişiklik yaparken, kendinizi bir sürü metodu değiştirirken bulabilirsiniz. Örneğin; yeni bir ürün tipi eklediğinizde, bulma, gösterme, sıralama yapan metotları da değiştirmek zorunda kalabilirsiniz.

#### Sebep

Genelde bu problemin sebebi, yazılımın kötü yapısı/tasarımı ve "copy-paste programming" in sonucudur.

#### Çözüm

- Sınıfın davranışını bölmek: [Extract Class](#extract-class).
- Farklı sınıflar aynı davranışa sahipse, sınıfları kalıtım yoluyla birleştirmek: [Extract Superclass](#extract-superclass) ve [Extract Subclass](#extract-subclass).

#### Sonuç

- Kod organizasyonunun iyileştirilmesi.
- Kod tekrarının azaltılması.
- Desteği basitleştirme.

### Shotgun Surgery

#### Problem

Herhangi bir değişiklik yapmak, birçok farklı sınıfta birçok küçük değişiklik yapmanızı gerektirir.

#### Sebep

Çok sayıda sınıf arasında tek bir sorumluluk dağılmıştır. Bu aşırı bir şekilde "Divergent Change" uygulamasından sonra olabilir.

#### Çözüm

- Mevcut sınıf davranışlarını tek bir sınıfa taşı: [Move Method](#move-method) ve [Move Field](#move-field).
- Kodları taşıdıkdan sonra, diğer sınıflar neredeyse boş kalıyorsa, boş kalan sınıflardan kurtul: [Inline Class](#inline-class).

#### Sonuç

- Daha iyi bir kod organizasyonu.
- Daha az kod tekrarı.
- Kolay bakım.

### Parallel Inheritance Hierarchies

#### Problem

Her ne zaman bir sınıf için alt sınıf oluştursan, kendini başka bir sınıf için alt sınıf oluşturma ihtiyacı duyarken bulabilirsin. İlişkili iki sınıf farklı dallardan hiyerarşi oluşturur.

#### Sebep

Hiyerarşi küçük olduğu sürece çok problem değil ama yeni sınıflar eklenmeye başlandıkça, değişiklik yapmak sürekli zorlaşmaya başlar.

#### Çözüm

- Hiyerarşilerin en tepesindeki sınıfların ikisini de kalıtım alan yeni bir hiyerarşi veya tepedeki paralel sınıfların birleşiminden yeni bir hiyerarşi: [Move Method](move-method) ve [Move Field](#move-field).

#### Sonuç

- Kod organizasyonu iyileşmesi.
- Kod tekrarını engellemesi.

#### Ne zaman göz ardı edilebilir?

Bazen paralel sınıf hiyerarşilerine sahip olmak, yazılımın mimarisiyle daha büyük karışıklıktan kaçınmanın bir yoludur. Hiyerarşileri çoğaltma girişimlerinizin daha çirkin kodlar ürettiğini tespit ederseniz, tüm değişikliklerinizi geri alın ve bu koda alışın.

### Comments

#### Problem

Metodun açıklayıcı yorumlarla dolu olması.

#### Sebep

Yorumlar genellikle yazılımcının kendi kodunun sezgisel olarak anlaşılmadığını veya açık olmadığını fark etmesiyle, iyi niyetle yazılır. Bu gibi durumlarda, yorumlar, kötü kokan kodun kokusunu gizleyen deodorant gibidir.

En iyi yorum bir metot veya sınıf için iyi bir addır.

Bir kod parçasının yorum yapılmadan anlaşılmayacağını düşünüyorsanız, kod yapısını yorumları gereksiz kılacak şekilde değiştirmeyi deneyin.

#### Çözüm

- Bir yorumun karmaşık bir ifadeyi açıklaması amaçlanıyorsa, ifade, anlaşılabilir alt ifadelere bölünmelidir: [Extract Variable](#extract-variable).
- Bir yorum kodun bir bölümünü açıklıyorsa, bu bölüm ayrı bir metot olarak yazılabilir. Yeni yöntemin adı, büyük olasılıkla, yorum metninin kendisinden alınabilir: [Extract Method](#extract-method).
- Bir metot zaten oluşturulmuşsa, ancak metodun ne yaptığını açıklamak için yorumlar hala gerekliyse, metoda açıklayıcı bir isim verin: [Rename Method](#rename-method).
- Sistemin çalışması için gerekli olan bir durum hakkında kurallar koymak için yorum yazmak gerekirse: [Introduce Assertion](#introduce-assertion).

#### Sonuç

Kod daha sezgisel ve açık hale gelir.

#### Ne zaman göz ardı edilebilir?

- Bir şeyin neden belirli bir şekilde uygulandığını açıklarken.
- Karmaşık algoritmaları açıklarken (algoritmayı basitleştirmek için tüm diğer yöntemler denendikten sonra).

### Duplicate Code

#### Problem

İki kod parçasının neredeyse aynı olması.

#### Sebep

Kod tekrarı, birden çok yazılımcının aynı yazılımın farklı bölümlerinde aynı anda çalıştığı durumlarda olur. Farklı işler üzerinde çalıştıklarından, diğer yazılımcının kendi ihtiyaçları için benzer bir kod yazmış olabileceğinin farkında olmayabilir.

Ayrıca, kodun belirli kısımları farklı göründüğü halde aslında aynı işi yaptığı durumlar da vardır. Bu tür bir kod tekrarını bulmak ve düzeltmek zor olabilir.

Bazen kod tekrarı bilerek yapılır. İşin yetişmesi gerek zamanın sonuna geliniyorsa ve mevcut kod gereken iş için "neredeyse doğru" ise acemi yazılımcı, "kopyala-yapıştır" yapmaktan kendini alamayabilir. Bazen de yazılımcı tembellik ederek kod tekrarına göz yumabilir.

#### Çözüm

- Aynı kod, aynı sınıfta iki veya daha fazla metotta bulunursa: [Extract Method](#extract-method).
- Aynı kod, aynı seviyedeki iki alt sınıfta bulunursa;
  - İki sınıf için de, alanı üste taşıma [Pull Up Field](#pull-up-field) yöntemini takip ederek: [Extract Method](#extract-method).
  - Tekrar eden kod bir yapıcı metot içinde ise: [Pull Up Constructor Body](#pull-up-constructor-body).
  - Eğer yinelenen kod benzer ancak tamamen aynı değilse: [Form Template Method](#form-template-method).
  - İki metot da aynı şeyi yapar, ancak farklı algoritmalar kullanırsa, en iyi algoritmayı seçin: [Substitute Algorithm](#substitute-algorithm).
- Tekrar eden kod iki farklı sınıfta bulunursa;
  - Sınıflar bir hiyerarşinin parçası değilse: [Extract Superclass](#extract-superclass).
  - Bir üst sınıf oluşturmak zor veya imkansızsa: [Extract Class](#extract-class).
- Çok sayıda koşullu ifade varsa ve aynı kodu çalıştırıyorsa (yalnızca koşullu ifadeler farklı), bu operatörleri tek bir koşulda birleştirin: [Consolidate Conditional Expression](#consolidate-conditional-expression) ve [Extract Method](#extract-method).
- Aynı kod, koşullu bir ifadenin tüm dallarında uygulanıyorsa: aynı kodu, koşul ağacının dışına yerleştirin: [Consolidate Duplicate Conditional Fragments](#consolidate-duplicate-conditional-fragments).

#### Sonuç

- Tekrar eden kodun birleştirilmesi, kodunuzun yapısını basitleştirir ve daha kısa hale getirir.
- Sadeleştirme + kısayol = basitleştirmesi kolay ve bakımı daha ucuz kod.

#### Ne zaman göz ardı edilebilir?

Çok nadir durumlarda, iki kod parçasının birleştirilmesi, kodu daha az sezgisel ve haha az açık hale getirebilir.

### Lazy Class

#### Problem

Bir sınıfın anlaşılması ve bakımı, zaman ve maliyet gerektirir. Dolayısıyla bir sınıf anlaşılmıyorsa ve istekleri yeterince karşılamıyorsa, o sınıf silinmelidir.

#### Sebep

Belki bir sınıf tamamen işlevsel olacak şekilde tasarlanmıştır, ancak refactoring yaptıktan sonra saçma derecede küçük hale gelmiştir. Veya gelecekte yapılacak ama daha yapılmamış bir özellik için tasarlanmış olabilir.

#### Çözüm

- Neredeyse işe yaramaz olan bileşenler için: [Inline Class](#inline-class).
- Az işlevli alt sınıflar için: [Collapse Hierarchy](#collapse-hierarchy).

#### Sonuç

- Kod uzunluğunu azaltır.
- Bakımı kolaylaştırır.

#### Ne zaman göz ardı edilebilir?

Koddaki basitlik ve açıklık arasınki dengeyi korumak şartıyla, gelecekteki gelişmelere yönelik niyetleri betimlemek için bir Lazy Class oluşturulabilir.

### Data Class

Martin Fowler'ın "Code Smell" dediği "Data Class", çoğu yazılımcı tarafından, "Code Smell" olarak kabul edilmiyor. Data Transfer Objects, Entity Objects vs. gibi birçok kullanımı var ve bunlar kaçınılmaz. Peki kim haklı?

### Dead Code

#### Problem

Bir değişken, parametre, alan, metot veya sınıfın artık kullanılmamasıdır (genellikle artık eskimiş olduğundan).

#### Sebep

Yazılımın gereksinimleri değiştiğinde veya düzeltmeler yapıldığında, eski kodu temizlemek için hiç kimse zaman harcamak istemez. Bu tür bir kod karmaşık kod bloklarında da bulunabilir.

#### Çözüm

Ölü kodu bulmanın en hızlı yolu iyi bir IDE kullanmaktır. Çözmek ise basit: sil.

- Kullanılmayan kodu ve gereksiz dosyaları silin.
- Gereksiz bir sınıfın bulunması durumunda: [Inline Class](#inline-class) ve [Collapse Hierarchy](#collapse-hierarchy).
- Gereksiz parametreleri kaldırmak için: [Remove Parameter](#remove-parameter).

#### Sonuç

- Kod uzunluğu azalır.
- Kolay bakım.

### Speculative Generality

#### Problem

Kullanılmayan bir sınıf, metot, alan veya parametrenin olmaması.

#### Sebep

Bazen kod, asla uygulanamayacak olan gelecekteki özellikleri desteklemek için yazılır. Sonuç olarak, kodun anlaşılması ve bakımı zorlaşır.

#### Çözüm

- Kullanılmayan soyut sınıfları kaldırmak için: [Collapse Hierarchy](#collapse-hierarchy).
- Gereksiz fonksiyonelliklerin başka bir sınıfa devredilmesi engellemek için: [Inline Class](#inline-class).
- Kullanılmayan metotlardan kurtulmak için: [Inline Method](#inline-method).
- Gereksiz parametreli metotlar için: [Remove Parameter](#remove-parameter).
- Kullanılmayan alanlar kolayca silinebilir.

#### Sonuç

- Temiz kod.
- Daha kolay bakım.

#### Ne zaman göz ardı edilebilir?

- Eğer bir framework geliştiriyorsanız, framework'ün kendisinin kullanmadığı ama kullanıcılarının kullanabileceği bir işlev için göz ardı edilebilir.
- Bazı birim testler, sınıf hakkında bilgileri kullanamk için ekstra alanlara ihtiyaç duyabilir. Bundan dolayı, gereksiz kod bloklarını silerken, birim testlerin bu kod bloklarını kullanıp kullanmadığından emin olun.

### Feature Envy

#### Problem

Bir metodun, başka bir sınıfın verisine, kendisindeki veriden daha fazla erişmesi.

#### Sebep

Alanlar veri sınıfına taşınırken oluşur. Bu durumda, veriyle işlem yapan kodları da bu sınıfa taşımak isteyebilirsiniz.

#### Çözüm

Genelde veri ve bu veriyi kullanan kod blokları birlikte değişir. Bundan dolayı hepsini aynı yerde tutmak gerekir. 

- Eğer metotlar taşınacaksa: [Move Method](#move-method).
- Bir metodun yalnızca bir kısmı başka bir nesnenin verilerine erişiyorsa: [Extract Method](#extract-method).
- Bir yöntem diğer birkaç sınıftan fonksiyonlar kullanıyorsa, ilk önce hangi sınıfların kullanılan veriyi içerdiğini belirleyin. Ardından metodu bu sınıfa diğer verilerle birlikte taşıyın. Alternatif olarak, metot küçük parçalara ayrılıp, farklı sınıflar içinde farklı metotlar olarak yer alabilirler: [Extract Method](#extract-method).

#### Sonuç

- Daha az kod tekrarı (veri işleme kodu merkezi bir yere yerleştirilirse).
- Daha iyi kod organizasyonu (veri işleme metotlarıyla veri aynı yerde olursa).

#### Ne zaman göz ardı edilebilir?

Bazen davranış bilerek verileri tutan sınıftan ayrı tutulur. Bunun genel avantajı, davranışı dinamik olarak değiştirme yeteneğidir.

### Inappropriate Intimacy

#### Problem

Bir sınıf, başka bir sınıfın "internal" alanlarını ve metotlarını kullanır. Sınıflar ne kadar birbirinden bağımsız olursa, yeniden kullanımı ve bakımı kolaylaşır.

#### Sebep

Kodların parça parça taşınması sırasında veya yanlış tasarımdan kaynaklanabilir.

#### Çözüm

- En hızlı ve basit çözüm, bir sınıfın metotlarını ve alanlarını başka sınıfa taşımak (eğer ilk sınıf bu metotlara tamamen ihtiyaç duymuyorsa): [Move Method](#move-method) ve [Move Field](#move-field).
- Sınıflar ilişkiliyse, o zaman gerçekten ilişkili sınıflar yapmak: [Extract Class](#extract-class) ve [Hide Delegate](#hide-delegate).
- Sınıflar karşılıklı olarak birbirine bağımlıysa: [Change Bidirectional Association to Unidirectional](#change-bidirectional-association-to-unidirectional).
- Bu "samimiyet" bir alt sınıfla üst sınıf arasındaysa: [Replace Delegation with Inheritance](#replace-delegation-with-inheritance).

#### Sonuç

- Kod organizasyonunu geliştirir. 
- Bakımı ve kodun yeniden kullanımını kolaylaştırır.

### Message Chains

#### Problem

Kodda `$a->b()->c()->d()` gibi bir dizi çağrı görürsünüz. Bu zincirler, sınıfların birbirlerine aşırı bağlı olmasına sebep olur. Bir sınıfta yapılan değişiklikler, diğerlerini de etkiler.

#### Sebep

Bir istemci bir nesne talep ettiğinde, talep edilen nesne başka bir tane daha ister ve bir mesaj zinciri oluşur. 

#### Çözüm

- Bir mesaj zincirini silmek için: [Hide Delegate](#hide-delegate).
- Bazen son nesnenin neden kullanıldığını düşünmek daha iyidir. Belki de bunu zincirin en önüne taşımak daha mantıklı hale gelecektir: [Extract Method](#extract-method) ve [Move Method](#move-method).

#### Sonuç

- Bir zincirin sınıfları arasındaki bağımlılığı azaltır. 
- Şişirilmiş kodun miktarını azaltır.

#### Ne zaman göz ardı edilebilir?

Aşırı agresif sınıf gizleme, işlevselliğin gerçekte nerede olduğunu görmenin zor olduğu kodlara neden olabilir. Aksi halde başka bir sıkıntı oluşabilir: [Middle Man](#middle-man).

### Middle Man

#### Problem

Bir sınıfın tek işi, tüm işleri başka sınıflara yaptırmak.

#### Sebep

"Message Chains" den kurtulmak için aşırı derecede kod başka sınıflara taşındığında bu durum oluşabilir. Diğer bir sebep de, bir sınıfın kodları parça parça başka sınıflara taşındığında ortaya çıkar. İçi boşalan bir sınıf, içi boş bir kabuk gibi kalır.

#### Çözüm

Bir sınıf içindeki bir çok metot başka sınıflara alınıyorsa: [Remove Middle Man](#remove-middle-man).

#### Sonuç

Daha az kod.

#### Ne zaman göz ardı edilebilir?

- Sınıflar arası bağımlılıkları önlemek için [Middle Man](#middle-man) eklenmiş olabilir.
- Bazı tasarım desenleri bilerek [Middle Man](#middle-man) yaratır.

### Incomplete Library Class

#### Problem

Er ya da geç, kütüphaneler kullanıcı ihtiyaçlarını karşılamayı durdurur. Tek çözüm ise kütüphaneyi değiştirmek ama kütüphanenin sadece okunabilir (read-only) olması, kütüphanenin değiştirilmesini imkansız hale getirir.

#### Sebep

Kütüphanenin yazarı, ihtiyaç duyduğunuz özellikleri sağlamadığında ya da geliştirmeyi reddettiğinde ortaya çıkar.

#### Çözüm

- Bir kütüphane sınıfına birkaç metot tanıtmak: [Introduce Foreign Method](#introduce-foreign-method).
- Bir sınıf kütüphanesinde büyük değişiklikler için: [Introduce Local Extension](#introduce-local-extension).

#### Sonuç

Kod çoğaltmasını azaltır (sıfırdan kendi kütüphanenizi oluşturmak yerine, hala mevcut olandan birisini kullanabilirsiniz).

#### Ne zaman göz ardı edilebilir?

Bir kütüphaneyi genişletmek, eğer kütüphanedeki değişiklikler koddaki değişiklikleri içeriyorsa ek iş üretebilir.

## REFACTORING TEKNİKLERİ

### Extract Method

- **Tersi:** [Inline Method](#inline-method)
- **Benzer:** [Move Method](#move-method)
- **Yardımcı olduğu diğer teknikler:** [Introduce Parameter Object](#introduce-parameter-object), [Form Template Method](#form-template-method), [Parameterize Method](#parameterize-method)
- **Düzeltiği kötü tasarımlar:** [Duplicate Code](#duplicate-code), [Long Method](#long-method), [Feature Envy](#feature-envy), [Switch Statements](#switch-statements), [Message Chains](#message-chains), [Comments](#comments), [Data Class](#data-class)

#### Problem

Gruplanabilecek kod bloklarının olması.

<details>
  <summary>C#</summary>
  
```csharp
public class ExtractMethodBad
{
    public void DoSomeThing()
    {
        // diğer kod blokları...

        // kullanıcı bilgilerini ekrana bas
        Console.WriteLine("Kullanıcı adı: ali_veli");
        Console.WriteLine("E-posta: ali_veli@mail.com");
    }
}
```
</details>
  
<details>
  <summary>Go</summary>
  
```go
package main

func DoSomeThing() {
    // diğer kod blokları...

    // kullanıcı bilgilerini ekrana bas
    fmt.Println("Kullanıcı adı: ali_veli")
    fmt.Println("E-posta: ali_veli@mail.com")
}
```
</details>


#### Çözüm

Bu kodu ayrı bir yeni metoda taşıyın ve eski kodun yerine bu metodu çağırın.

<details>
  <summary>C#</summary>
  
```csharp
public class ExtractMethodGood
{
    public void DoSomeThing()
    {
        // diğer kod blokları...

        WriteUserInformationToConsole();
    }

    // kullanıcı bilgilerini ekrana bas
    private static void WriteUserInformationToConsole()
    {
        Console.WriteLine("Kullanıcı adı: ali_veli");
        Console.WriteLine("E-posta: ali_veli@mail.com");
    }
}
```

</details>

<details>
  <summary>Go</summary>
  
```go
package main

func DoSomeThing() {
    // diğer kod blokları...

    writeUserInformationToConsole()
}

// kullanıcı bilgilerini ekrana bas
func writeUserInformationToConsole() {
    fmt.Println("Kullanıcı adı: ali_veli")
    fmt.Println("E-posta: ali_veli@mail.com")
}
```

</details>

#### Neden?

- Bir metodda ne kadar çok satır bulunursa, metodun ne yaptığını bulmak o kadar zor olur.
- Gruplanan kodlar, ihtiyaç halinde başka yerden de çağrılabilir.
- Sonraki başka bir refactoring tekniği için de bir adım olabilir.

#### Faydaları

- Daha okunabilir kod. Metot ismi içindeki, gruplanmış kod satırlarının ne yaptığına dair fikir verir.
- Daha az kod tekrarı. Kodun yeniden kullanılabilirliği artar. Tüm satırları tekrar yazmaktansa, metot çağrısı yapılır.
- Bağımsız kod bölümlerini birbirinden izole eder, bu da daha az hata demektir. Çünkü kod bloğunun bakımı tamamen kendi sınırları içinde yapılır.

### Inline Method

- **Tersi:** [Extract Method](#extract-method)
- **Düzeltiği kötü tasarımlar:** [Speculative Generality](#speculative-generality)

#### Problem

Bir metodun gövdesinin, metodun kendisinden daha açık olması.

<details>
  <summary>C#</summary>
  
```csharp
public class InlineMethodBad
{
    public int GetMultiplier(int number)
    {
        return IfNumberPositive(number) ? 1 : -1;
    }

    // bu metoda gerek yok
    private static bool IfNumberPositive(int number)
    {
        return number >= 0;
    }
}
```
</details>

#### Çözüm

Metot çağrısını, metodun içeriğiyle değiştirin ve metodun kendisini silin.

<details>
  <summary>C#</summary>
  
```csharp
public class InlineMethodGood
{
    public int GetMultiplier(int number)
    {
        return number >= 0 ? 1 : -1;
    }
}
```
</details>

#### Neden?

Bir metot basitçe başka bir metodu çağırır ve bunda aslında bir problem yoktur. Problem, bu şekilde gereksiz metotların artmasıdır. Böyle çok fazla metot olunca, kafa karıştırıcı kodlar ortaya çıkar. 

#### Faydaları

Gereksiz metotların sayısını en aza indirerek, kodu daha basit hale getiririz.

### Extract Variable

- **Tersi:** [Inline Temp](#inline-temp)
- **Benzer:** [Extract Method](#extract-method)
- **Düzeltiği kötü tasarımlar:** [Comments](#comments)

#### Problem

Anlaşılması zor koşulların/ifadelerin olması.

<details>
  <summary>C#</summary>
  
```csharp
public class ExtractVariableBad
{
    public double GetTotalPrice()
    {
        var order = new Order();// get order 

        return order.Quantity * order.ItemPrice -
               Math.Max(0, order.Quantity - 500) * order.ItemPrice * 0.05 +
               Math.Min(order.Quantity * order.ItemPrice * 0.1, 100);
    }
}
```
</details>

#### Çözüm

İfadenin/koşulların veya bölümlerinin sonucunu kendi kendini açıklayıcı olan ayrı değişkenlere taşıyın.

<details>
  <summary>C#</summary>
  
```csharp
public class ExtractVariableGood
{
    public double GetTotalPrice()
    {
        var order = new Order();// get order 

        var basePrice = order.Quantity * order.ItemPrice;
        var quantityDiscount = Math.Max(0, order.Quantity - 500) * order.ItemPrice * 0.05;
        var shipping = Math.Min(basePrice * 0.1, 100);

        return basePrice - quantityDiscount + shipping;
    }
}
```
</details>

#### Neden?

Kod içerisindeki uzun ifadeler kodun anlaşılmasını zorlaştırır. Kodu karmaşıklaştırır ve gereksiz uzatır. Kodu daha anlaşılır, daha kısa yapmak ve [Extract Metot](#extract-metot) için bir adım oluşturmak.

#### Faydaları

Daha okunabilir ve anlaşılabilir kod. İfadenin ne anlama geldiğini ismi ile anlatan değişkenler.

#### Dezavantajları

Çok fazla değişken oluşmasına sebep olabilir. Ama kodun daha okunabilir olması bu yan etkiyi dengeler.

### Inline Temp

---

## KAYNAKLAR

**NOT**: Yararlanılan kaynaklar sürekli eklenecek. 

- https://refactoring.guru/
- http://www.yilmazcihan.com/yazilim-gelistirmede-teknik-borc/
- https://softwareengineering.stackexchange.com/questions/365017/when-is-primitive-obsession-not-a-code-smell
- https://martinfowler.com/bliki/DataClump.html
- http://blog.ploeh.dk/2015/09/18/temporary-field-code-smell/
- https://dzone.com/articles/code-smell-series-parallel-inheritance-hierchies
- https://softwareengineering.stackexchange.com/questions/338195/why-are-data-classes-considered-a-code-smell
- https://stackoverflow.com/questions/16719270/is-data-class-really-a-code-smell
- http://wiki3.cosc.canterbury.ac.nz/index.php/Middle_man_smell
- https://refactoring.com/catalog/extractVariable.html
