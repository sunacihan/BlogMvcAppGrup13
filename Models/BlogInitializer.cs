using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogMvcApp.Models
{
    //İnitializer sınıfı database içerisinde değişiklik oldukça veritabanını silip tekrar oluşturur ve test verilerini burada barındırır.
    public class BlogInitializer:DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            List<Category> kategoriler = new List<Category>() {
               new Category {KategoriAdi="Felsefe"},
               new Category {KategoriAdi="Çocuk"},
               new Category {KategoriAdi="Din"},
               new Category {KategoriAdi="Tarih"},
               new Category {KategoriAdi="Yazılım"}       
            };

            foreach(var item in kategoriler)
            {
                context.Kategoriler.Add(item);
            }
            context.SaveChanges();


            List<Blog> bloglar = new List<Blog>() { 
            
                new Blog {Baslik="Törebilim / Ethica", Aciklama="Spinoza’nın Etika’sı modern etik karakteri çözümlemeye yönelik bir girişimdir ", EklenmeTarihi=DateTime.Now.AddDays(-10), Anasayfa=true,Onay=true,Icerik="Spinoza’nın ussallığı, giderek geometrik biçimi içinde bile olsa, yalnızca kültürel yapıların geçiciliğini ve değersizliğini ortaya sermekle kalmaz, ama yalancı felsefeler için saltık eleştirinin, usun eleştirisinin bakış açısını da sunar. Spinoza’nın ussal düşünceye güveni anlaşıldığında, kuşkucu-despotik Aydınlanmanın Spinoza’ya yaklaşımını duygudaş gösterme çabaları yakışıksız girişimlerdir. Ve tözü özdek olarak yorumlama girişimleri felsefeye yabancı ideolojiye ait hermeneutik gereksizliklerdir.",Resim="1.jpg", CategoryId=1},
                 new Blog {Baslik="Momo", Aciklama="Zaman, yaşamın kendisidir. Ve yaşamın yeri yürektir.", EklenmeTarihi=DateTime.Now.AddDays(-10), Anasayfa=false,Onay=true,Icerik="Bir gün hayaletimsi topluluk “duman adamlar” ortaya çıkar. İnce hesaplı planlar kurup insanların zamanını çalarlar. Onları durduracak tek kişiyse Momo’dur.Momo elinde bir çiçek, koltuğunun altında bir kaplumbağa ve gizemli Hora Usta’nın da yardımıyla koskoca duman adamlar ordusunun karşısında tek başına durur. Acaba Momo, zamanı çalan adamları tek başına alt edebilecek midir?",Resim="momo.jpg", CategoryId=2},
                  new Blog {Baslik="Bir Eğitimci Olarak Hz. Muhammed (sas.) ve Öğretim Metotları", Aciklama="Abdulfettah Ebu Gudde", EklenmeTarihi=DateTime.Now.AddDays(-10), Anasayfa=true,Onay=false,Icerik="Merak ve öğrenme duygusu insanlık tarihi kadar eski bir kavramdır. Her insan doğar doğmaz bilmeye, öğrenmeye başlar ve çok azı öğrendiklerini öğretme melekesi kazanır. Elinizdeki eser, bilginin her şeyi kuşattığı bu çağda değişen ve gelişen eğitim metotlarına öncülük edecek ipuçları sunmaktadır. Ayrıca muazzam hayatıyla tüm insanlığa örnek olan Peygamber Efendimiz’in öğretimde kullandığı farklı ve etkili yöntemleri sade bir üslupla anlatmaktadır. Otuz yılı aşkın bir çalışmanın ürünü olan bu müstesna eser cehaletin düşmanı olan her yaştan okuyucunun başucu kitabı olmayı hak etmektedir.",Resim="ebugudde.jpg", CategoryId=3},
                  new Blog {Baslik="İstanbul’dan Sayfalar", Aciklama="DÜNYA BAŞKENTİ İSTANBUL’UN TADINA DOYULMAYAN SAYFALARI…", EklenmeTarihi=DateTime.Now.AddDays(-8), Anasayfa=true,Onay=true,Icerik="“İstanbul bütün insanlığın zenginliğidir. Sayfaları çevrilmekle bitmeyen bir kitap; seyrine doyum olmayan bir resimdir. Bu iki bin yıllık dünya metropolünü gözümüz gibi sakınmalıyız.”",Resim="ilber.jpg", CategoryId=3},

                new Blog {Baslik="c# delegates hakkında", Aciklama="c# delegates hakkında c# delegates hakkında c# delegates hakkında", EklenmeTarihi=DateTime.Now.AddDays(-10), Anasayfa=false,Onay=true,Icerik="c# delegates hakkında c# delegates hakkında c# delegates hakkında c# delegates hakkında",Resim="AAAAAA&text=900x300.png", CategoryId=4},
                new Blog {Baslik="Devlet/Platon", Aciklama="M.Ö. 427-347 yılları arasında yaşamış olan Eflatun düşlediği en iyi devleti, Sokrates'le birlikte, bu kitapta anlatır.", EklenmeTarihi=DateTime.Now.AddDays(-15), Anasayfa=true,Onay=true,Icerik="Devlet'te iki düşüncenin çatışmasına tanık oluruz:1) İnsanlar doğuştan iyi ve eşittirler; toplumun kötü düzeni onları bozuyor, güçlüler güçsüzleri eziyor.Kanunlar güçlülerin elinde güçsüzlere karşı silah okuyor.2) İnsanlar doğuştan ne iyi ne de eşittirler.Yalnızca güçlü ve güçsüzler vardır.Güçlünün güçsüzü yönetmesi, doğa gereğidir ve doğrudur. İnsan haklı olmaya değil, güçlü olmaya bakmalıdır.Buradan yola çıkarak Devlet'in, bugün başlığında ele aldığımız birikimin kaynaklarından biri olduğunu rahatlıkla söyleyebiliriz.",Resim="platon.jpg", CategoryId=1},
               
                new Blog {Baslik="Harry Potter ve Felsefe Taşı", Aciklama="“Harry, elleri titreyerek zarfı çevirince mor balmumundan bir mühür gördü; bir arma – koca bir ‘H’ harfinin çevresinde bir aslan, bir kartal, bir porsuk, bir de yılan.”", EklenmeTarihi=DateTime.Now.AddDays(-17), Anasayfa=true,Onay=true,Icerik="HARRY POTTER sıradan bir çocuk olduğunu sanırken, bir baykuşun getirdiği mektupla yaşamı değişir: Başvurmadığı halde Hogwarts Cadılık ve Büyücülük Okulu’na kabul edilmiştir. Burada birbirinden ilginç dersler alır, iki arkadaşıyla birlikte maceradan maceraya koşar. Yaşayarak öğrendikleri sayesinde küçük yaşta becerikli bir büyücü olup çıkar.",Resim="harry.jpg", CategoryId=2},
               
                new Blog {Baslik="Dünyevileşme Her Yerden Aşk Kalpten Vurura", Aciklama="İhsan Şenocak HÜKÜM KİTAP", EklenmeTarihi=DateTime.Now.AddDays(-5), Anasayfa=true,Onay=true,Icerik="‘‘Aşk’’, Mü’mini bir alemden başka bir aleme götürür. Bu yüzden aşk dilinde sevgiliye ‘‘yar’’ denir. Sonra her şey gibi aşk da yardan ağyara düştü. Gönül, edeple girilen bir dergah olmaktan çıktı, bir kapısından girilip diğerinden çıkılan sahipsiz bir hana döndü. Şehvetten kurtulmanın adı olan aşk; şehvetin, şöhretin karargahı oldu. Aşk, makamından düşünce söz de mahallinden çıktı, meddahların dilinde menfaat devşirme aracı oldu. Dünya kendine gelsin, insan uyansın diye alimler, arifler ruhunu Kur’an-ı Kerim’den alan nice sözler söyledi.",Resim="senocak.jpg", CategoryId=3},
                new Blog {Baslik="Beyaz Zambaklar Ülkesinde", Aciklama="Grigory Petrov", EklenmeTarihi=DateTime.Now.AddDays(-10), Anasayfa=false,Onay=false,Icerik="“Kutsal kitaplarda şöyle bir hikâye yazar: Bir zaman­lar güçlü, zalim bir hükümdarın sarayının duvarların­da ateşle yazılmış kelimeler varmış: “Mane tekel fares!” Bu kelimeleri hiç kimse anlayamamış. Hâkim Danyal’ın kendisi kelimeleri şöyle yorumlamış: “Bu ateşten yazılar, ilginç bir olayın geleceğini haber veriyor. Bunların anla­mı şudur: Devlet, artık yaşama gücünü yitirmiştir. Kaçı­nılması imkânsız bir sona yani yıkılmaya mahkûmdur.",Resim="zambak.jpg", CategoryId=4},

                new Blog {Baslik="c# delegates", Aciklama="c# delegates hakkında c# delegates hakkında c# delegates hakkında", EklenmeTarihi=DateTime.Now.AddDays(-10), Anasayfa=true,Onay=false,Icerik="c# delegates hakkında c# delegates hakkında c# delegates hakkında c# delegates hakkında",Resim="AAAAAA&text=900x300.png", CategoryId=4},

            };
            foreach(var item in bloglar)
            {
                context.Bloglar.Add(item);
            }
            context.SaveChanges();

            List<Login> giris = new List<Login>
            {
                new Login { Isim="Dilara", SoyIsim="Yılmaz", Email="dilara@gmail.com",Sifre="123"},
                new Login { Isim="suna", SoyIsim="cihan", Email="suna@gmail.com",Sifre="123"}
            };
            foreach (var item in giris)
            {
                context.Girisler.Add(item);
            }
            context.SaveChanges();

            base.Seed(context);
        }
    }
}