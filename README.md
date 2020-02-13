# TÜRKÇE REFACTORING KILAVUZU

## ÖN SÖZ

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
  - [Replace Temp with Query](#replace-temp-with-query)
  - [Split Temporary Variable](#split-temporary-variable)
  - [Remove Assignments to Parameters](#remove-assignments-to-parameters)
  - [Replace Method with Method Object](#replace-method-with-method-object)
  - [Substitute Algorithm](#substitute-algorithm)
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

Hiç kimse, projeye zarar vermek için bilerek kötü kod yazmaz. Herkes elinden gelenin en iyisini yapmak ister. Kötü kod yazmaya iten sebepler vardır. Kötü yazılan kod da, ileride başımıza dert açabilir.

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

Refactoring, başkalarının kodlarını anlamayı kolaylaştırır. Yeni özellik eklemek için kodun iyi anlaşılması gereklidir. Kod ne kadar temiz olursa o kadar anlaşılır olur. Dolayısıyla yeni özellik eklemeden önce kodlar refactor edilebilir.

#### Hata düzeltme

Yine hata bulmak için öncelikle kodun iyi anlaşılması lazımdır. Daha iyi anlamak için kodu refactor ederiz. Refactor işlemi sırasında, çoğunlukla hata bulunur.

#### Kod inceleme (code review)

Kod inceleme, hem kodu yazan hem de inceleyen için en faydalı iştir. Kod inceleme yaparken, hata bulmak daha kolay ve hızlı olur. İleride yapılabilecek daha büyük hatalar için de, önceden bilgi sahibi olmayı sağlar.

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

Yazılımcı her zaman kodu kendisi yazmak ister. Kendi yazmadığı kodlara güvenmez/güvenmek istemez. Bundan dolayı da kod yazmak, kod okumaktan kolay gelir yazılımcıya. Her yeni gelen yazılımcı, bir yandan okumadan kod ekleyip, bir yandan da kullanılmayan kodları silinmeyince, metot gittikçe şişer, okunamaz ve bakımı yapılamaz hale gelir. Okunamayan kod, sürekli yeni kodların eklenmesini tetikleyerek kısır döngü oluşturur.

İki satır kod için yeni bir metoda ihtiyaç yok diye düşünüp, tüm kodu var olan metotlara eklemek, her zaman yazılımcıya daha kolay gelir. Bu da kodu işin içinden çıkılmaz bir hale sokar.

#### Çözüm

Anlaşılması için illa açıklanması gereken her kod bloğu ayrı bir metoda taşınabilir. Kodların anlaşılması için taşınan metodun ismi, metodun ne yaptığına dair kesin bilgi vermelidir. Böylece metodu kullananlar, metodun ne yaptığını, içindeki kodları okumadan anlayabilir.

Kod içerisindeki koşullu ifadeler, döngüler her zaman, kodları farklı metoda taşımak için birer adaydır. Kullanılabilecek refactoring teknikleri: [Extract Method](#extract-method), [Temp with Query](#temp-with-query), [Introduce Parameter Object](#introduce-parameter-object), [Preserve Whole Object](#preserve-whole-object), [Replace Method with Method Object](#replace-method-with-method-object) ve [Decompose Conditional](#decompose-conditional).

#### Sonuç

Sürekli büyüyen kodlar için, tekrar eden, aynı işi yapan, belki de yanlış çalışan kodlar olabilir. Bu kodlar içinde hata bulmak, tekrar eden kodları temizlemek ve bakım yapmak çok zor iştir. Bu kötü tasarımdan kurtulursak, tüm bu olumsuzluklardan da kurtuluruz.

#### Performans

Kodun daha anlaşılır, bakım yapılabilir ve daha az hataya açık olması, her zaman maliyeti düşürür ve geliştirme hızını artırır. Ayrıca daha iyi tasarlanmış bir kod, daha hızlı çalışır. Daha iyi tasarlanmış bir kodda gereksiz kodlarda olmaz. Yani aslında performansın dengelenmesinin yanında, fazladan geliştirme hızı ve maliyet düşüşü sağlamış oluruz.

### Large Class

#### Problem

Bir sınıfta gereğinden fazla alan, metot, özellik ve dolayısıyla fazla kod olması.

#### Sebep

Uzun metotlardaki gibi, uzun sınıfların oluşmasındaki en büyük sebep, kolay olmasından dolayı, kodu okumak yerine, direkt koda ekleme yapmasıdır.

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

Bir diğer hata da kullanımı kolay ve anlaşılır olan değişkenlerde veritabanına ait olabilecek veriler tutmak. En kötüsü ise, bir sınıfın her alanının, bir dizide veri olarak tutulması. Nesne oluşturmak o kadar zor gelir ki, bir dizide bu nesnenin her alanı için bir veri tutulur.

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

Daha okunabilir, kısa, bakımı kolay kodlar. Daha okunabilir kod içerisinde, gereksiz kod tekrarları da daha rahat farkedilir, dolayısıyla, kod tekrarlarından da kurtulunabilir.

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

Kodun anlaşılabilirliğini ve organizasyonunun kalitesini artırır. Parametreler dağınık olarak, etrafta duracağına, bir sınıf içinde toplanmış olur. Kod tekrarı engellenir, dolayısıyla kod kısalır, okunabilirliği artar ve bakımı kolaylaşır.

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

Bir sınıf içinde, belirli bir kapsam dahilinde geçerli ve birbirine bağımlı olarak tanımlanmış, geçici alanların olması. Bu alanların, sınıfı geneli için ifade ettiği bir şey yoktur. Sadece bazı metotlar bunların değerlerini değiştir ve kullanır. Bu alanların ne için kullanıldığını bulmak çok zordur.

#### Sebep

Karmaşık algoritmalar, her zaman çok fazla değişken kullanırlar. Bazen bu değişkenleri parametre olarak, metoda geçmek gerekir ve yazılımcı bunun kötü bir tasarım olduğunu bildiği için bunu yapmak istemez ama başka bir kötü tasarım yapabilir. Algoritma için gerekli olan değişkenleri, sınıfın alanları olarak tanımlar ve bu alanlar sadece ilgili algoritma tarafından kullanılır Dolayısıyla bu algoritma dışında bu değişkenlerin hiç bir manası yoktur.

#### Çözüm

Bu kötü tasarımdan kurtulmak için, ilişkili olan işlemleri farklı sınıfa taşıyabilir veya `Null object pattern` yöntemini kullanabiliriz.

Kullanılabilecek refactoring teknikleri: [Extract Class](#extract-class), [Replace Method with Method Object](#replace-method-with-method-bject), [Introduce Null Object](#introduce-null-object).

#### Sonuç

Daha rahat okunabilir ve sade kodlar.

### Refused Bequest

#### Problem

Bir sınıfın, kalıtım aldığı sınıfın çok az özelliğini veya metodunu kullanması.

#### Sebep

Kodun yeniden kullanılması, kalıtım ve benzer tasarım desenlerini kullanma isteği bazen bunların gereksiz kullanımına bizi iter. Ama hiyerarşi kurmak istediğimiz sınıflar çok farklı olabilir. Örneğin birisi ördek, diğeri oyuncak ördek olabilir.

"The Liskov Substitution Principle" şöyle der: Ördeğe benziyor, ördek gibi ses çıkarıyor ama bataryaya ihtiyacı varsa, büyük ihtimalle yanlış bir soyutlama peşindesin.

#### Çözüm

Kalıtımla da çözülebilir, kalıtım olmadan da çözülebilir. Kalıtım mantıklı değilse, sınıflar paralel hiyerarşiye çekilir.

Kalıtım yapmak uygunsa, kalıtım alan sınıf içindeki gereksiz metotlardan, alanlardan ve özelliklerden kurtulup, başka bir üst sınıf oluşturup, uygun şekilde yeniden hiyerarşi sağlanabilir.

Kullanılabilecek refactoring teknikleri: [Replace Inheritance with Delegation](#replace-inheritance-with-delegation), [Extract Superclass](#extract-superclass).

#### Sonuç

Kodun okunabilirliğini ve organizasyonunu artırır. Artık, neden `Chair` sınıfının `Animal` sıfından türediğini merak etmeye gerek yok.

### Alternative Classes with Different Interfaces

#### Problem

Farklı `interface` kullanan veya hiç `interface` kullanmayan, ama aynı işi yapan kod bloklarının, sınıfların veya metotların olması. Bu sınıfların içindeki aynı işleri yapan metotların isimleri, imzaları falan farklıdır. Hangisinin ne zaman kullanılacağı tam olarak belli değildir. Birbirlerinin alternatifleri bile olurlar.

#### Sebep

Yazılımcının kod okumaması, kötü tasarlanmış kodların olması, sürekli yeni yazılımcıların katılmasından kaynaklı olarak, yazılımcıların, muhtemelen böyle bir işlevi yapan kod parçalarından habersiz olarak, aynı işi yapan kod blokları eklemesinden kaynaklanır.

#### Çözüm

Sınıfların ve metotların isimlerinin, imzalarının ve uygulanmalarının birebir aynı olması sağlanmalıdır. Birebir aynı olduğunda sınıflardan birisinin gereksiz olduğu anlaşılırsa, gereksiz olan silinir. Sınıfların ortak kullandıkları bölümler varsa bunlar, ortak başka bir sınıfa alınabilir.

Kullanılabilecek refactoring teknikleri: [Rename Method](#rename-method), [Move Method](#move-method), [Add Parameter](#add-parameter), [Parameterize Method](#parameterize-method), [Extract Superclass](#extract-superclass).

#### Sonuç

Daha az ve temiz, kolay okunabilir, kolay bakım yapılabilir, geliştirme maliyeti azalmış kod altyapısı sağlar.

#### Ne zaman göz ardı edilebilir?

Bazı sınıflar farklı kütüphanelerde olabilir ve bunlar kendi içinde geliştirilir ve versiyonlanırlar. Bu gibi durumlarda, birleştirmek, silmek ve taşımak mantıksızdır.

### Divergent Change

#### Problem

Bir kod bloğunu değiştirirken, kendinizi silsile halinde başka kodları da değiştirirken bulabilirsiniz. Örneğin; bir nesne değiştiği zaman, onun listelendiği, sıralandığı, eklenip, düzenlendiği gibi ilişkili yerlerinde değişmesi gerekebilir.

#### Sebep

Kötü tasarım ve kötü kod altyapısından veya birbirine aşırı bağımlı kod parçalarının olmasından kaynaklanan bir durum olabilir.

#### Çözüm

Sınıfların davranışlarını bölmek veya duruma göre eğer aynı işi yapıyorlarsa birleştirmek.

Kullanılabilecek refactoring teknikleri: [Extract Class](#extract-class), [Extract Superclass](#extract-superclass), [Extract Subclass](#extract-subclass).

#### Sonuç

Daha iyi kod organizasyonu, kod tekrarının azaltılması, bakımın kolaylaşması.

### Shotgun Surgery

#### Problem

Kodun çok daha derinlerindeki, büyük bir sıkıntının, bize görünen küçük kısmı. Buzdağının görünen yüzü de diyebiliriz. Küçük gibi görünen bu kötü tasarımı düzeltmeye kalktığında çok farklı yerlerin etkilendiğini görürüz.

#### Sebep

Genelde sorumlulukların iyi ayrılamamasından (Seperation of Concerns ve Single Responsibility), tasarım desenlerinin acemice ve kötü uygulanmasından kaynaklanabilir.

#### Çözüm

Çözüm basit, nesneleri ve davranışları kuralına uygun olarak ayırmak, gereksiz nesneleri ve davranışları silmek.

Uygulanabilecek refactoring teknikleri: [Move Method](#move-method), [Move Field](#move-field), [Inline Class](#inline-class).

#### Sonuç

Daha okunabilir, daha kolay bakım yapılabilir, kod tekrarlarının az olduğu, daha iyi bir kod organizasyonu sağlar.

### Parallel Inheritance Hierarchies

#### Problem

Hiyerarşik bir sınıf grubunun, bu grupla ilişkili ve paralelinde başka bir sınıf hiyerarşisinin olması. Mesela `Vehicle` sınıfından türeyen, `Car` ve `Truck` nesnelerinin, paralelinde bu hiyerarşiyle alakalı, `XmlFormatter` sınıfından türeyen `CarXmlFormatter` ve `TruckXmlFormatter` sınıflarının olması durumu. İki ağaç da birbirine paralel olarak dallanıyor.

#### Sebep

Okunamayacak kadar kötü tasarımlı kod altyapısı ile çalışmaktan dolayı, kod/tasarım tam olarak anlaşılmamış olabilir. Bir diğer sabep ise tecrübesizlikten kaynaklanmış olabilir. 

#### Çözüm

Bu kötü tasarımı çözmenin birçok yöntemi var. Bu yöntemlerin hepsi farklı bir tasarım desenini içeriyor. Örneğin, en tepedeki iki sınıfı da kalıtım alan yeni bir hiyerarşi veya tepedeki sınıfların birleşiminden yeni bir hiyerarşi oluşturulabilir. Çok farklı tasarımlarla çözülebilir ve bu tasarımlar da, tasarım desenleri konusuna girmektedir, ama temelde kullanılacak refactoring teknikleri bellidir.

Kullanılabilecek refactoring teknikleri: [Move Method](move-method), [Move Field](#move-field).

#### Sonuç

Kod tekrarının engellenerek, daha iyi bir kod altyapısının oluşmasının sağlanması. Daha iyi tasarıma sahip kodun, bakımının kolaylaşması.

#### Ne zaman göz ardı edilebilir?

Paralel hiyerarşi, her ne kadar değişiklik maliyeti yüksek kod üretse de, dengeli kullanımda aslında daha okunabilir bir kod yapısı sunar. Bazen bu tasarımdan kurtulmak için, çok daha karışık ve gereksiz tasarımlara doğru kayabiliriz. Paralel hiyerarşi çok fazla dallanmadığı sürece göz ardı edilebilir.

### Comments

#### Problem

Kod bloklarını açıklamak için yazılmış yorumların olması. Bir söz var; kod yazmak espri yapmak gibidir, eğer açıklamak zorunda kalıyorsan, kötü yazılmıştır. Yorum satırları, kod içerisine yazılmış döküman gibidir. Kod her değiştiğinde yorum da değişmelidir. Ama çoğu zaman kimse kod değiştikçe, yorum satırlarını da güncellemez. Kod bir şey yapıyorken, yorum başka şey anlatıyor olabilir.

#### Sebep

İyi tasarlanmamış, kötü isimlendirilmiş, kod tekrarının çok olduğu, okunması zor olan kodlar için, yazılımcı yorum yazma yoluna gidebilir. Oysaki en iyi yorum, isimlendirmeler ve iyi tasarımdır. Yazılımcı okunmayan kodu yorumlarla anlatmaya çalışmıştır.

#### Çözüm

Yorum satırlarından kurtulmak için, kodu parçalayarak, yorum gereken kod bloklarını ayrı yerlere taşıyıp, güzel bir isimlendirme yapmak gerekir. Açıklayıcı parçalara ayrılan ve açıklayıcı isimlendirmeler yapılan kod blokları hala yorum satırlarına ihtiyaç duyuyorsa, yorum yerine, "assertion" ifadeleri yazılabilir.

Kullanılabilecek refactoring teknikleri: [Extract Variable](#extract-variable), [Extract Method](#extract-method), [Rename Method](#rename-method), [Introduce Assertion](#introduce-assertion).

#### Sonuç

Kodu okumak ve anlamak daha kolaylaşır. Koda bakınca, içini okumadan, daha net bir şekilde ne yaptığını anlayabilir. Dolayısıyla daha kolay bakım yapılabilir hale gelir.

#### Ne zaman göz ardı edilebilir?

Bazı durumlarda yorum satırları yazılabilir. Mesela; bir metot içinde yapılan hesaplamanın neden bu şekilde yapıldığı, çıktısında ne beklendiği, örnek girdi gibi kısımlar için yorum yazılabilir. Bazende karmaşık bir algoritmada, tüm refactoring işlemlerinden sonra bile hala anlaşılmayan noktalar kalıyorsa, yine yorum satırları eklenebilir.

### Duplicate Code

#### Problem

Gereksiz tekrar eden kodların olması.

#### Sebep

Kod tekrarı yapmak çok kolaydır. Yazılımcının kod okumayı sevmediğini belirtmiştik. Kod okunmadığı zaman, gerekli dökümanlarının olmaması durumları da eklenince, belkide kodda var olan fonksiyonellikler, bizim haberimizin olmamasından dolayı tekrardan yazılabilir.

Kod tekrarları, yazılımın farklı yerlerinde çalışan ve çok birbirleri ile kesişen işler olmadığında veya yazılımcıların birbirinden haberi olmamasından dolayı, iki yazılımcı aynı işi yapan kodları aynı anda yazabilir. Bazende, kodun bazı kısımları, isimleri falan farklı olduğu halde aynı işi yaptığı durumlar da olabilir. Bunun sebebi de, yine kötü tasarımdan dolayı var olan koddan bihaber olmak ve yine aynı işi yapan kodları yazmak.

Bazende kod tekrarı bilerek yapılabilir. Kodun çalışan kısımlarını, o an günü kurtarmak için yazılımcı kopyala-yapıştır ile alıp kullanmak isteyebilir. Bu düşünce bazen acemilikten, bazen de tembellikten olabilir.

#### Çözüm

Temel olarak bu sorunun çözümü ya parçalamaktır ya da tam tersi birleştirmektir. Bazen de tekrar eden kodlardan/algoritmalardan en iyisini seçip, diğerini silmekdir.

Uygulanabilecek refactoring teknikleri: [Extract Method](#extract-method), [Pull Up Field](#pull-up-field), [Pull Up Constructor Body](#pull-up-constructor-body), [Form Template Method](#form-template-method), [Substitute Algorithm](#substitute-algorithm), [Extract Superclass](#extract-superclass), [Extract Class](#extract-class), [Consolidate Conditional Expression](#consolidate-conditional-expression), [Consolidate Duplicate Conditional Fragments](#consolidate-duplicate-conditional-fragments).

#### Sonuç

Kodun kısalması, sadeleşmesi ve daha kolay anlaşılması sağlanır. Daha iyi anlaşılan kod, daha rahat bakım yapılabilir.

#### Ne zaman göz ardı edilebilir?

Kodun, kod tekrarı olan durumlarda, bazen daha iyi anlaşıldığı nadir durumlar olabilir. Bu durumda kodların birleştirilmesi, bazen kodun anlaşılmasını engelleyebilir.

### Lazy Class

#### Problem

Neredeyse hiçbir şey yapmayan, gerekliliğinin sorgulanmasına sebep olan sınıfların olması.

#### Sebep

Sınıf zaman içerisinde değişikliklere uğrar. İçerisindeki işlevlerin taşınması, rafactor edilmesi gibi nedenlerden dolayı, sınıfın içi boşalabilir veya içerisindeki kodlar artık çok da fazla iş yapmaz duruma gelebilir. Ya da daha sonra yapılacak bir özelliklik için, baştan tasarlanmış olabilir.

#### Çözüm

Sınıfın işlevleri başka sınıfa taşınabilir. Bu sınıflar aynı hiyerarşide veya üst hiyerarşideki sınıflar olabilir.

Uygulanabilecek refactoring teknikleri: [Inline Class](#inline-class), [Collapse Hierarchy](#collapse-hierarchy).

#### Sonuç

Gereksiz kodların silinmesi ile kod daha kısa, sade ve anlaşılabilir olur. Kodun bakımı daha da kolaylaşır.

#### Ne zaman göz ardı edilebilir?

Gelecekteki gelişmelere yönelik, önceden fikir vermesi, yol haritası çizmesi bakımından, bu tarz gereksiz sınıflarında oluşturulabileceğinden bahsetmiştik. Kodun karmaşıklığını artırmadan, sadeliği ve okunabilirliği bozmadan, dengeli bir kullanım durumunda göz ardı edilebilir.

### Data Class

Martin Fowler'ın "Code Smell" dediği "Data Class", çoğu yazılımcı tarafından, "Code Smell" olarak kabul edilmiyor. Data Transfer Objects, Entity Objects vs. gibi birçok kullanımı var ve bunlar kaçınılmaz. Peki kim haklı?

### Dead Code

#### Problem

Artık kullanılmayan kod parçası (alan, parametre, değişken, metot, sınıf).

#### Sebep

Yeni geliştirmeler, eklemeler, refactoring işlemlerinden sonra eski kodların, işe yarayıp yaramadığını anlamak ve bunlara aksiyon almak için çoğu zaman kimse vakit ayırmak istemez. Üstelik bir de kötü ve okunması zor bir kod altyapısı ile çalışıyorken, bu işe yaramaz kod parçalarının bulunması da ayrıca zordur. Bundan dolayıda, işe yaramaz kod blokları oluşabilir. 

#### Çözüm

İşe yaramazyan kodları bulmanın en iyi yolu, iyi bir IDE veya IDE ile uyumlu, kod eklentilerin kullanılmasıdır. Bu en etkili ve hızlı yöntemdir. Tabiki işe yaramayan kod parçaları bulununca yapılacak ilk şey silmek veya taşımak.

Uygulanabilecek refactoring yöntemleri: [Inline Class](#inline-class), [Collapse Hierarchy](#collapse-hierarchy), [Remove Parameter](#remove-parameter).

#### Sonuç

Gereksiz kodların silinmesi daha sade, kısa ve okunabilir kod sağlar. Böylece bakım maliyeti düşer.

### Speculative Generality

#### Problem

Gelecekte kullanılacak diye eklenen ama hiç kullanılmayan kod parçalarının olması.

#### Sebep

Gelecekte yapılacak bir özellik için, belki fikir de versin diye önceden eklemek isteyebiliriz. Ama bu eklenen kodlar, kullanılmadı için sistem hakkında yanlış bilgi veriyor olabilirler. Başka bir yazılımcı bunun varlığını sorgulayabilir ve kodun bakımını zorlaştırır.

#### Çözüm

Kullanılmayan kodların silinmesi veya taşınması.

Kullanılabilecek refactoring teknikleri: [Collapse Hierarchy](#collapse-hierarchy), [Inline Class](#inline-class), [Inline Method](#inline-method), [Remove Parameter](#remove-parameter).

#### Sonuç

Daha kısa, sade ve temiz kod. Dolayısıyla bakımı daha kolay kod.

#### Ne zaman göz ardı edilebilir?

Eğer bir framework geliştiriyorsanız, framework'ün kendisinin kullanmadığı ama kullanıcılarının kullanabileceği bir işlev için göz ardı edilebilir.

Bazı birim testler, sınıf hakkında bilgileri kullanmak için ekstra alanlara ihtiyaç duyabilir. Bundan dolayı, gereksiz kod bloklarını silerken, birim testlerin bu kod bloklarını kullanıp kullanmadığından emin olun.

### Feature Envy

#### Problem

Bir sınıf içindeki metotun, başka bir sınıfın verisine, bulunduğu sınıfınkinde fazla erişmesi. Örneğin; `Customer` sınıfındaki, `getPhoneNumber` adındaki metot, `Phone` adındaki sınıfın `"(" + phone.getAreaCode() + ") " + phone.getPrefix() + "-" + phone.getNumber();` şeklinde metotlarını çağırıyorsa.

#### Sebep

Bazen sınıflar parçalanırken, alanların veri sınıfına taşınamasından sonra, o alanlarla işlem yapan metotların, diğer sınıfta kalmasından dolayı ortaya çıkar.

#### Çözüm

Çözüm; alanları taşıdığımızda, bu alanları kullanan metotları da birlikte taşımamız gerekir.

Kullanılabilecek refactoring teknikleri: [Move Method](#move-method), [Extract Method](#extract-method).

#### Sonuç

Metotlar ve bu metotların kullandığı alanlar aynı yerde olursa, kod merkezi bir yerde olur ve merkezi bir yerden yönetilir. Böylece kod tekrarının önüne geçilebilir ve daha iyi bir kod organizsyonu ile beraber daha kolay bir bakım maliyeti sağlanır.

#### Ne zaman göz ardı edilebilir?

Bazen, davranışın veriden ayrı tutulması ile, davranışın bağımsız olması ve daha dinamik bir şekilde yönetilmesi, değiştirilmesi sağlanabilir. Bu gibi durumlarda göz ardı edilebilir.

### Inappropriate Intimacy

#### Problem

Sınıfların, birbirlerinin alanlarını ve metotlarını çok kullanması ve böylece birbirlerine çok bağımlı olmaları.

#### Sebep

Yanlış tasarım veya refactoring sırasında, parça parça taşınan kodlardan dolayı, bazı parçaların diğer sınıfta kalmasından kaynaklanabilir.

#### Çözüm

Çözüm kodların uygun şekilde taşınması varsa gereksiz kod blokları, bunların silinmesi.

Uygulanabilecek refactoring teknikleri: [Move Method](#move-method), [Move Field](#move-field), [Extract Class](#extract-class), [Hide Delegate](#hide-delegate), [Change Bidirectional Association to Unidirectional](#change-bidirectional-association-to-unidirectional), [Replace Delegation with Inheritance](#replace-delegation-with-inheritance).

#### Sonuç

Sade, kısa ve kolay anlaşılır kod. Dolayısıyla, daha sağlam kod altyapısı ve daha az bakım maliyeti.

### Message Chains

#### Problem

Birbirine aşırı sınıfların oluşmasına neden olan, `classA.classB.classC.classD` şeklindeki zincirlerin olması. Bir sınıfta yapılan değişiklikler, diğer sınıfları da etkileyebilir ve bakım maliyetini artırır.

#### Sebep

Kod altyapısında başka kötü tasarımlar olması, yazılımcının tasarım iyi bir tasarım yapmak yerine, hızlıca bir sınıf içinde başka bir sınıfı alan olarak tanımlamasından (bazen tembellik, bazen tecrübesizlik) dolayı bu şekilde kötü bir tasarım ortaya çıkabilir.

#### Çözüm

İlişkili sınıflar arasındaki bağı kaldırmak için, zinciri kırıp, sınıfları farklı hiyerarşilere alıp, gereksiz yerlerin silinmesini sağlamak.

Uygulanabilecek refactoring teknikleri: [Hide Delegate](#hide-delegate), [Extract Method](#extract-method), [Move Method](#move-method).

#### Sonuç

Sınıflar arasındaki bağ azaldığı için, bakım maliyeti de azalır. Kod daha sade ve kısa hale gelebilir.

#### Ne zaman göz ardı edilebilir?

Sınıflar arasındaki bağın aşırı derecede kırılması da doğru olmayabilir. Bu kezde ilişkili sınıflar arasındaki bağlantılı işlevlerin, gerçekte nerede olduğunu görmek zorlaşır. Bu kötü tasarımı çözmek isterken, dengeli olunmaması durumunda, başka bir kötü tasarıma sebep olur; [Middle Man](#middle-man).

### Middle Man

#### Problem

Bir sınıfın, başka sınıflara iş yaptırmaktan başka işinin olmaması.

#### Sebep

Hiyerarşik bir şekilde birbirini çağıran sınıflardan ([Message Chains](#message-chains)) kurtulmak için yapılan refactoring aşırıya kaçınca, bu şekilde bir kötü tasarım ortaya çıkabiliyor. Diğer bir sebep de, sınıfın kodlarının, başka sınıflara taşınmasından dolayı, ilgili sınıfta sadece o metotların çağrıları kalabilir. Bu da içi boşalmış, sadece başka sınıfların metotlarını çağıran bir sınıfa dönüşmesine sebep olur.

#### Çözüm

Tek çözüm var, o da bu sınıfı silmek.

Uygulanabilecek refactoring teknikleri: [Remove Middle Man](#remove-middle-man).

#### Sonuç

Daha anlaşılır, temiz ve sade kod. Böylece daha az bakım maliyeti.

#### Ne zaman göz ardı edilebilir?

Sınıflar arası aşırı bağımlılığı engellemek için bu tasarım kullanılabilir. Bu tarz tasarımlarda refactoring, dengeli olmalıdır. Bir tarafı aşırı olursa [Middle Man](#middle-man), diğer tarafı aşırı olursa [Message Chains](#message-chains) oluşabilir.

### Incomplete Library Class

#### Problem

Yeni ihtiyaçlara cevap veremeyen kütüphanelerin olması.

#### Sebep

Kütüphaneler kullanıcıların ihtiyaçlarını karşılayamaz duruma duruma geldiğinde, kütüphaneti geliştirmek ve değiştirmek gerekebilir. Ama kütüphanenin kapalı olması, sadece okunabilir olması durumlarında, kütüphaneyi yazanların bakımı ve geliştirmeyi durdurmasından dolayı geliştirmeler durma noktasına gelebilir.

#### Çözüm

Kütüphaneye dışarıdan metotlar ve extension'lar geliştirilebilir.

Uygulanabilecek refactoring teknikleri: [Introduce Foreign Method](#introduce-foreign-method), [Introduce Local Extension](#introduce-local-extension).

#### Sonuç

Kütüphaneleri sistemden çıkarmak ve sıfırdan yazmak yerine eklemeler yaparsak, projede çok fazla kod olmaz.

#### Ne zaman göz ardı edilebilir?

Kütüphaneyi genişletmek için kendi kodumuzda da çok fazla değişikliğe yol açıyorsa, fazladan iş çıkarabilir. Bu durumda, göz ardı edilebilir.

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

Bu kodu ayrı bir yeni metoda taşıyın ve eski kodun yerine bu metodu çağırın. Bu yeni metoda, ne yaptığını(nasıl yaptığını değil) anlatan güzel bir isim verilir.

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
- Mümkün olduğunca uzun ve comment(yorum) satırına ihtiyaç duyan kod parçalarından kaçınmak gerekir. Bunun yerine kısa ve güzel isimlendirilmiş metodlar kullanılmalı. Çünkü genelde küçük metodları(kodu) okumak commenti okumaktan daha kolaydır.

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

<details>
  <summary>Go</summary>

```go
package main

func GetMultiplier(number int) int {
    if ifNumberPositive(number) {
        return 1
    } else {
        return -1
    }
}

// bu metoda gerek yok
func ifNumberPositive(number int) bool {
    return number >= 0
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

<details>
  <summary>Go</summary>

  [Go Playground ile çalıştır](https://play.golang.org/p/ZGXxzGxKSRZ)
```go
package main

func GetMultiplier(number int) int {
    if number >= 0 {
        return 1
    } else {
        return -1
    }
}
```
</details>

#### Neden?

Bir metot basitçe başka bir metodu çağırır ve bunda aslında bir problem yoktur. Problem, bu şekilde gereksiz metotların artmasıdır. Böyle çok fazla metot olunca, kafa karıştırıcı kodlar ortaya çıkar. Bu yüzden değişken kullanılabilecekse ve bu işi karmaşıklaştırmayacaksa, gereksiz yere metot kullanmak tavsiye edilmez.

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

<details>
  <summary>Go</summary>

```go
package main

func GetTotalPrice() float64 {
    var order = Order{} // get order

    return order.Quantity * order.ItemPrice -
           math.Max(0, order.Quantity - 500) * order.ItemPrice * 0.05 +
           math.Min(order.Quantity * order.ItemPrice * 0.1, 100)
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

<details>
  <summary>Go</summary>

  [Go Playground ile çalıştır](https://play.golang.org/p/f8MFx7GoHG3)
```go
package main

func GetTotalPrice() float64 {
    var order = Order{} // get order

    var basePrice = order.Quantity * order.ItemPrice
    var quantityDiscount = math.Max(0, order.Quantity - 500) * order.ItemPrice * 0.05
    var shipping = math.Min(basePrice * 0.1, 100)

    return basePrice - quantityDiscount + shipping
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

- **Yardımcı olduğu diğer teknikler:** [Replace Temp with Query](#replace-tempwith-query), [Extract Method](#extract-method)

#### Problem

Tek görevi, geçici olarak veri tutan değişkenlerin olması.

<details>
  <summary>C#</summary>

```csharp
public class InlineTempBad
{
    public int CalculateVolume(int l, int w, int h)
    {
        var volume = l * w * h;

        return volume;
    }
}
```
</details>

#### Çözüm

Geçici değişken yerine ifadenin kendisi direk kullanılabilir.

<details>
  <summary>C#</summary>

```csharp
public class InlineTempGood
{
    public int CalculateVolume(int l, int w, int h)
    {
        return l * w * h;
    }
}
```
</details>

#### Neden?

İfadelerin çok karmaşık olmadığı durumlarda geçici değişken kullanıp kodu uzatmanın anlamı yoktur. İfadenin kendisini kullanmak daha sade bir kod yapısı sağlar.

#### Faydaları

Kodu biraz sadeleştirir. Önemi çoğu zaman kritik seviyede değildir.

#### Dezavantajları

Bazen geçici değişkenler, sonraki kod satırlarında da kullanılıyor olabilir. Geçici değişken kullanılmadığında, ifade her defasında lazım olduğunda yeniden hesaplanıyorsa, o zaman geçici değişken kullanmak mantıklıdır. Böyle durumlarda bu tekniği uygulamak yanlıştır.

### Replace Temp with Query

#### Problem

Bir ifadenin sonucunu daha sonra kullanmak üzere lokal bir değişkende tutulması.

<details>
  <summary>C#</summary>

```csharp
  double getTotalCartPrice()
  {
      double totalPrice = productQuantity * productPrice;

      return totalPrice < 200 ? totalPrice + 80 : totalPrice;
  }
```
</details>

#### Çözüm

İfadenin sonucunu döndüren bir metot oluşturun. Değişken kullandığınız yerde metodu çağırın.

<details>
  <summary>C#</summary>

```csharp
double getTotalCartPrice()
{
    double totalPrice = getTotalPrice();

    return totalPrice < 200 ? totalPrice + 80 : totalPrice;
}

double getTotalPrice()
{
    return productQuantity * productPrice;
}
```
</details>

#### Neden?

 Bir ifade bazı durumlarda birden fazla metot tarafından kullanılabilir. Bu durumlarda ifadenin sonucunu döndüren bir metot oluşturulup diğer metotlar tarafından kullanılabilir.
 
 #### Faydaları

Kodun okunabilirliği artar. Örneğin productPrice * 0.9 ifadesini sonuç olarak döndüren getTax() metodunun vergi miktarını hesapladığını kolaylıkla anlayabilirsiniz.

### Split Temporary Variable

#### Problem

Bir değişkeni farklı yerlerde farklı ifadelerin sonuçlarını tutacak şekilde kullanmak.

<details>
  <summary>C#</summary>

```csharp
double r = 3;
double h = 10;

void calculateCylinderInformations()
{
    double cylinderInformation = 2 * Math.PI * r * (h + r);
    Console.WriteLine("Cylinder Area: " + cylinderInformation);

    cylinderInformation = Math.PI * Math.Pow(r, 2) * h;
    Console.WriteLine("Cylinder Volume: " + cylinderInformation);
}
```
</details>

#### Çözüm

Farklı ifadelerin sonuçlarını tutmak için farklı değişkenler kullanın. Böylece bir değişkenin birden fazla görevi olmaz.

<details>
  <summary>C#</summary>

```csharp
double r = 3;
double h = 10;

void calculateCylinderInformations()
{
  double cylinderArea = 2 * Math.PI * r * (h + r);
  Console.WriteLine("Cylinder Area: " + cylinderArea);

  double cylinderVolume = Math.PI * Math.Pow(r, 2) * h;
  Console.WriteLine("Cylinder Volume: " + cylinderVolume);
}
```
</details>

#### Neden?

Bir değişkene farklı görevler yapmak üzere farklı değerler atayabilirsiniz. Ancak ilerleyen zamanlarda kodlar üzerinde değişiklik yapmanız gerektiğinde zorlanabilirsiniz. Değişkenleri, belirli bir değeri tutacak şekilde oluşturabilirsiniz.

#### Faydaları

Her bir değişkenin sadece bir görevi olur. Bir değişkene farklı yerlerde farklı değerler atanması sonucu oluşabilecek sorunların önüne geçilir. Kodların bakımı kolaylaşır ve okunabilirlik artar. 

### Remove Assignments to Parameters 

#### Problem

Metot gövdesinde parametreye değer atamak.

<details>
  <summary>C#</summary>

```csharp
public Dictionary<string, double> CreateDummyDiscount(double originalPrice)
{
  Dictionary<string, double> priceValues = new Dictionary<string, double>();

  if(originalPrice >= 1000)
  {
    originalPrice += originalPrice * 20 / 100;
    priceValues.Add("displayedPrice", originalPrice);

    originalPrice -= originalPrice * 5 / 100;
    priceValues.Add("discountedPrice", originalPrice);
  }
  else
  {
    originalPrice += originalPrice * 30 / 100;
    priceValues.Add("displayedPrice", originalPrice);

    originalPrice -= originalPrice * 5 / 100;
    priceValues.Add("discountedPrice", originalPrice);
  }

  return priceValues;
}
```
</details>

#### Çözüm

Parametrelerin değerlerini değiştirmek yerine lokal değişkenler kullanın.

<details>
  <summary>C#</summary>

```csharp
public Dictionary<string, double> CreateDummyDiscount(double originalPrice)
{
  double displayedPrice = 0;
  double discountedPrice = 0;

  Dictionary<string, double> priceValues = new Dictionary<string, double>();

  if (originalPrice >= 1000)
  {
    displayedPrice = originalPrice + originalPrice * 20 / 100;
    discountedPrice = displayedPrice - displayedPrice * 5 / 100;
  }
  else
  {
    displayedPrice = originalPrice + originalPrice * 30 / 100;
    discountedPrice = displayedPrice - displayedPrice * 5 / 100;
  }

  priceValues.Add("displayedPrice", displayedPrice);
  priceValues.Add("discountedPrice", discountedPrice);

  return priceValues;
}
```
</details>

#### Neden?

Bu refactoring tekniğinin uygulanmasının sebepleri, Split Temporary Variable tekniği ile aynıdır. Burada lokal bir değişken yerine bir parametre ile uğraşılır. Parametrenin değerinin değiştirilerek işlem yapılması beklenmedik sonuçlar alınmasına sebep olabilir. Metodu anlatan dokümanın içeriği olması gerektiği gibi anlaşılır olmayabilir.

#### Faydaları

Her bir değişkenin bir görevi olur. Kodların okunabilirliği ve bakımı kolaylaşır. 

### Replace Method with Method Object

#### Problem

Değişkenlerin iç içe geçmiş olduğu uzun bir metot varsa ve metodu refactoring için [Extract Method](#extract-method) kullanılamaması.

<details>
  <summary>C#</summary>

```csharp
public class GameState
{
  public double GetScore()
  {
    double cofficentForSmallEnemies;
    double cofficentForBigEnemies;

    //Uzun hesaplamalar sonrasında bir değer hesaplandığını düşünelim.
    return 1;
  }
}
```
</details>

#### Çözüm

Metodu yeni bir sınıf oluşturup sınıfın içerisinde yazın. Böylece değişkenler sınıfın bir parçası haline gelirler.
Daha sonra metodu aynı sınıfın içerisinde birkaç parçaya bölebilirsiniz.

<details>
  <summary>C#</summary>

```csharp
public class GameState
{
  public double GetScore()
  {
    return new ScoreCalculator(this).Calculate();
  }

}

public class ScoreCalculator
{
  private double cofficentForSmallEnemies;
  private double cofficentForBigEnemies;

  public ScoreCalculator(GameState gameState)
  {
    //Gerekli bilgiler gameState objesinden alınıyor.
  }

  public double Calculate()
  {
    //Hesaplamalar bu metotta yapılıyor.
    return 1;
  }
}
```
</details>

#### Neden?

Çok uzun metotlarda birbirinden ayrı tutulması zor olan değişkenleri birbirlerinden ayıramazsınız.
Yapılması gereken ilk şey, metodu bir sınıfa taşıyıp lokal değişkenleri sınıfın bir parçası olarak ayarlamaktır.
Problemi sınıf düzeyine getirmeyi sağlar. Uzun ve karmaşık bir metodu küçük parçalara bölmeyi sağlar.  

#### Faydaları

Uzun bir metodun kendi sınıfında barındırılması boyutun artmasını engeller.
Aynı zamanda metodun sınıf içerisinde alt metotlara bölünmesine olanak sağlar.

#### Dezavantajları

Programın karmaşıklığını artıran bir class daha eklenmiş olur.

### Substitute Algorithm

#### Problem

Mevcut algoritmayı yenisiyle değiştirmek. Bazı durumlarda bunu yapma gereksinimi duyabilirsiniz. Örneğin kullanmakta olduğunuz framework yapmakta olduğunuz bir işlemi size daha kolay ve belleği daha az kullanacak şekilde yapabilme imkanı sağlıyorsa değişiklik yapabilirsiniz.

<details>
  <summary>C#</summary>

```csharp
List<string> enemyList = new List<string>() { "soldier", "soldier", "soldier", "bionic human", "tank" };

List<string> UseGunsByEnemyType(List<string> enemyList)
{
  List<string> gunList = new List<string>();

  foreach (var enemy in enemyList)
  {
      if (enemy.Equals("soldier"))
      {
        gunList.Add("pistol");
      }
      else if (enemy.Equals("bionic human"))
      {
        gunList.Add("shotgun");
      }
      else if (enemy.Equals("tank"))
      {
        gunList.Add("rpg");
      }
  }

  return gunList;
}
```
</details>

#### Çözüm

Kodlarınızı yapılmakta olan işlemi değiştirmeyecek şekilde daha iyi bir hale getirebilirsiniz.

<details>
  <summary>C#</summary>

```csharp
List<string> enemyList = new List<string>() { "soldier", "soldier", "soldier", "bionic human", "tank" };
Dictionary<string, string> gunsForEnemies = new Dictionary<string, string>() {
  { "soldier", "pistol" },
  { "bionic human", "shotgun" },
  { "tank", "rpg" }
};


public List<string> UseGunsByEnemyType(List<string> enemyList, Dictionary<string, string> gunsForEnemies)
{
  List<string> gunList = new List<string>();

  foreach (var enemy in enemyList)
  {
      gunList.Add(gunsForEnemies.SingleOrDefault(x => x.Key == enemy).Value);
  }

  return gunList;
}
```
</details>

#### Neden?

- Yapmakta olduğunuz işlemi daha kolay ve verimli bir şekilde yapan bir algoritma bulduysanız eski algoritmanızı yeni algoritma ile değiştirebilirsiniz.
- Kullanmakta olduğunuz algoritma ilerleyen zamanlarda, iyi bilinen bir kütüphaneye veya bir framework' e dahil edilebilir. Bu durumda bakımı kolaylaştırmak için değişikliğe gidebilirsiniz.

#### Nasıl?

- Algoritmayı basitleştirdiğinizden emin olun. Extract metodunu kullanarak gereksiz kodları diğer metotlara taşıyın.
- Yeni bir metot oluşturarak yeni algoritmanızı yazın. Yeni algoritmanızı eskisi ile değiştirin ve test edin.
- Sonuçlar eşleşmezse eski kodunuzu geri getirip karşılaştırma yapın. 
- Kodlarınızı yeniden düzenledikten sonra bütün testleriniz başarılı ise eski algoritmanızı silebilirsiniz.

---
## KAYNAKLAR

**NOT**: Yararlanılan kaynaklar sürekli eklenecek. Bu doküman anlatım tarzı olarak https://refactoring.guru/ sitesindekine benzer bir yapı kullanıyor. Ana kaynak olarak bu siteden yararlanılıyor. Bu sitenin sahibi Alexander Shvets, içeriğin üzerine bina ettiği başka bir içeriği paralı olarak sattığı için, bedava olan kısmın birebir çevirisinin MIT lisans altında GitHub'da olmasını istemiyor. Dolayısıyla bu dokümanın içeriği olabildiğince özgün, araştırılmış, tecrübe ile desteklenmiş, farklı kaynaklardan düzenlenmiş içeriklerden oluşmaktadır.

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
- https://dzone.com/articles/code-smell-shot-surgery
- https://stackoverflow.com/questions/696350/avoiding-parallel-inheritance-hierarchies
