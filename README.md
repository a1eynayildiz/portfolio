# Aleyna Yıldız · Portfolyo

Canlı site: https://aleyna-portfolio.onrender.com

ASP.NET Core 8 MVC ile yazılmış, tek sayfalık kişisel portfolyo. Bölümler yukarıdan aşağıya sırayla akar: Anasayfa, Hakkımda, Projelerim, Staj Deneyimlerim, Başarılarım ve İletişim. Projelere tıklandığında ayrıntılar ve "Proje Linki" bir panelde açılır; panelin adresi (`/#projeler/blog-project` gibi) doğrudan paylaşılabilir.

## Yerelde çalıştırma

```bash
dotnet run
```

Site `http://localhost:5000` adresinde açılır. Geliştirme ortamında iletişim formu e-posta ayarı olmadan da görünür; gönderimde "doğrudan e-posta ile ulaşın" mesajı döner.

## İçeriği güncelleme

Sitedeki tüm metinler `Models/PortfolioData.cs` dosyasındadır; görünüm dosyalarına dokunmanız gerekmez.

- **Yeni proje:** `AllProjects` listesine bir `Project` ekleyin. `DemoUrl` doluysa "Proje Linki" canlı demoya, boşsa GitHub deposuna gider. Boş bırakılan isteğe bağlı alanlar (Problem, Sonuçlar, Rol vb.) sayfada gösterilmez.
- **Taslaklar:** `IsDraft = true` olan kayıtlar sitede görünmez. ParkPilot ve Afet Pusulası şu anda taslaktır; köşeli parantezli alanları doldurup `IsDraft = false` yapın.
- **Kapak görseli:** Gerçek bir ekran görüntüsünü `wwwroot/images/projects/` klasörüne koyup `CoverImage` alanına yolunu yazın (1600 × 900 px, WebP veya PNG önerilir). Hazır SVG kapaklar, ekran görüntüsü olmayan projeler için yer tutucudur.
- **CV:** PDF dosyasını `wwwroot/cv/` klasörüne koyup `CvUrl` sabitine yolunu yazın; "CV'mi indir" butonları kendiliğinden görünür.

## İletişim formu

Form, mesajları [Resend](https://resend.com) API'si ile e-posta kutusuna iletir. Resend, e-postayı HTTPS üzerinden gönderdiği için SMTP portlarının kapalı olduğu ortamlarda (örneğin Render'ın ücretsiz planı) da çalışır.

Ayarlar depoda tutulmaz; barındırma ortamında ortam değişkeni olarak tanımlanır:

- `Resend__ApiKey` (zorunlu): Resend panelinden alınan API anahtarı.
- `Resend__To` (isteğe bağlı): Mesajların gideceği adres. Boşsa sitedeki e-posta adresi kullanılır. Alan adı doğrulanmadıysa Resend hesabının e-posta adresiyle aynı olmalıdır.
- `Resend__From` (isteğe bağlı): Gönderen adres. Alan adı doğrulanana kadar varsayılan değer (`onboarding@resend.dev`) kullanılır.

Resend tanımlı değilse uygulama SMTP ayarlarına (`Smtp__Host`, `Smtp__Port`, `Smtp__Username`, `Smtp__Password`, `Smtp__From`, `Smtp__To`) bakar. İkisi de tanımlı değilse canlı sitede form yerine doğrudan e-posta kartı gösterilir.

Güvenlik önlemleri: istek sahteciliğine karşı antiforgery belirteci, sunucu tarafında yeniden doğrulama, botlar için görünmez tuzak alanı ve aynı IP adresinden 10 dakikada en fazla 3 gönderim sınırı.

## Render'da yayınlama

Proje kökündeki `Dockerfile` ile yayınlanır.
