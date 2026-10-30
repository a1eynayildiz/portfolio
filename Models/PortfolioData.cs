namespace AleynaPortfolio.Models;

/// <summary>
/// Sitedeki tüm içerik burada. Yeni proje, deneyim veya başarı eklemek için
/// yalnızca bu dosyayı düzenlemek yeterlidir.
/// </summary>
public static class PortfolioData
{
    // ── Kimlik ve bağlantılar ─────────────────────────────────────────────
    public const string FullName = "Aleyna Yıldız";
    public const string Title = "Back-End Geliştirici";
    public const string Location = "İstanbul, Büyükçekmece";
    public const string Email = "aleynayildizc@gmail.com";
    public const string Github = "https://github.com/a1eynayildiz";
    public const string LinkedIn = "https://linkedin.com/in/aleynayildiz1";
    public const string Medium = "https://medium.com/@aleynayildizz";

    /// <summary>
    /// CV dosyasını wwwroot/cv/ klasörüne koyup yolunu buraya yazın
    /// (örneğin "/cv/Aleyna-Yildiz-CV.pdf"). Boşken CV butonları gizlenir.
    /// </summary>
    public const string? CvUrl = null;

    public const string HeroIntro =
        "C#, .NET ve Python ile üretim ortamına dokunan backend işler yapıyorum. " +
        "Son olarak teknik şartnameleri yapay zekâyla analiz eden bir karar destek uygulaması geliştirdim; " +
        "öncesinde bir CBS uygulamasının veri aktarım modüllerini yazdım.";

    public static readonly string[] AboutParagraphs =
    {
        "\"Bu neden böyle çalışıyor?\" sorusunun peşinden gitmeyi, backend tarafında üretim " +
        "ortamına dokunan işler yapmayı seven bir bilgisayar mühendisliği son sınıf öğrencisiyim.",

        "En son Ekspa Bilgisayar'da, iki kişilik bir ekiple teknik şartname PDF'lerini büyük dil modeli (LLM) " +
        "ile analiz eden Presales AI uygulamasını geliştirdim. PowerGIS'te C# ve PostgreSQL ile çok katmanlı " +
        "bir CBS uygulamasının veri yükleme ve form yapılandırma modüllerini yazdım; GETAP'ta ise Django " +
        "REST Framework ile API tasarımı ve Celery + Redis ile asenkron görev yönetimi üzerine çalıştım.",

        "Siber İz platformunda siber güvenlik ve web geliştirme alanlarında düzenli olarak " +
        "teknik blog yazıları yayımladım. Düzce Üniversitesi Kariyer Topluluğu - Finans " +
        "Departmanı üyesi olarak bütçe planlaması ve etkinlik gelir-gider tablolarının " +
        "hazırlanmasında görev aldım."
    };

    public const string EducationSchool = "Düzce Üniversitesi";
    public const string EducationProgram = "Bilgisayar Mühendisliği (Lisans)";
    public const string EducationPeriod = "2023 — 2027";
    public const string EducationGpa = "3.20 / 4.00";

    public static Dictionary<string, List<string>> Skills => new()
    {
        ["Diller ve çatılar"] = new() { "C#", ".NET", "ASP.NET", "Windows Forms", "Python", "Django", "Django REST Framework", "React", "SQL" },
        ["Veritabanı"] = new() { "PostgreSQL", "MSSQL", "Django ORM" },
        ["Araçlar"] = new() { "Git", "GitHub", "Docker", "Postman", "Redis", "Celery", "Celery Beat", "JWT", "Groq API" },
        ["Kavramlar"] = new() { "RESTful API tasarımı", "Çok katmanlı mimari", "ETL", "Asenkron görevler", "LLM entegrasyonu" },
        ["Yabancı Dil"] = new() { "Türkçe (Anadil)", "İngilizce (B1+)" }
    };

    // ── Staj ve iş deneyimleri (en yeni en üstte) ─────────────────────────
    public static List<Experience> AllExperiences => new()
    {
        new Experience
        {
            Company = "Ekspa Bilgisayar",
            Role = "Yazılım / Bilgi Teknolojileri Stajyeri",
            Period = "Ağustos 2026 — Eylül 2026",
            Context = "İki kişilik bir ekiple, teknik şartname PDF'lerini analiz eden yapay zekâ destekli bir satış öncesi karar destek uygulaması (Presales AI) geliştirdik.",
            Highlights = new()
            {
                "React, Django REST Framework, PostgreSQL, Groq API ve Docker ile uygulamanın geliştirilmesinde yer aldım.",
                "Şartname maddelerinin ayrıştırılmasına, teknik kriterlerin büyük dil modeli (LLM) ile çıkarılmasına, farklı üreticilerin ürünlerinin karşılaştırılmasına ve uyumluluk puanlarının hesaplanmasına katkı sağladım.",
                "Malzeme listesi (BOM) oluşturma, geçmiş kayıt yönetimi, Excel'e aktarma, kaynak doğrulama, önbellekleme ve hata yönetimi özelliklerini geliştirdim.",
                "Ekip içinde görev dağılımı, sürüm kontrolü ve kod birleştirme için Git ve GitHub kullandım.",
                "Farklı departmanlarla görüşerek şirketin iş süreçlerini, departman sorumluluklarını ve ekipler arası iş akışlarını öğrendim."
            },
            Skills = new() { "React", "Django REST Framework", "PostgreSQL", "Groq API", "LLM entegrasyonu", "Docker" }
        },
        new Experience
        {
            Company = "PowerGIS",
            Role = "Backend Geliştirici",
            Period = "Mayıs 2026 — Haziran 2026",
            Context = "C# ve PostgreSQL ile geliştirilen çok katmanlı bir Coğrafi Bilgi Sistemi (CBS) uygulamasında veri yükleme ve form yapılandırma modülleri üzerinde çalıştım.",
            Highlights = new()
            {
                "Veri erişim ve arayüz katmanını ayrı class library projelerine ayırarak çok katmanlı mimariye geçirdim; modüller arası bağımlılığı azaltarak kod tekrarını düşürdüm ve test edilebilirliği artırdım.",
                "Excel dosyalarını OleDb ile okuyup parametreli SQL sorgularıyla PostgreSQL'e aktaran ETL modülünü geliştirdim; dinamik kolon eşleştirme arayüzü sayesinde farklı şablondaki dosyalar tek modülle işlenebilir hale geldi.",
                "Çok sekmeli yapılandırma ekranları, DataGridView tabanlı görüntüleme formları ve dosya yükleme arayüzleri dahil birden fazla Windows Forms ekranı tasarlayarak son kullanıcının çok adımlı veri girişini tek arayüzde topladım."
            },
            Skills = new() { "C#", "PostgreSQL", "Katmanlı mimari", "ETL", "Windows Forms", "CBS" }
        },
        new Experience
        {
            Company = "GETAP",
            Role = "Yazılım Geliştirme Stajyeri",
            Period = "Haziran 2025 — Ağustos 2025",
            Context = "İki farklı Django web uygulamasının backend ekibinde yer aldım.",
            Highlights = new()
            {
                "İki farklı Django web uygulamasının backend tarafında aktif rol alarak canlıya çıkan özelliklere doğrudan katkı sağladım.",
                "Django REST Framework ile RESTful API endpoint'leri tasarladım; serializer ve view katmanlarını geliştirerek frontend ekibinin ihtiyaç duyduğu veri sözleşmelerini netleştirdim.",
                "Django ORM ile ilişkisel veritabanı şemasını modelleyerek dinamik içerikli sayfaların üretimini sağladım; Git tabanlı akışta düzenli kod inceleme süreçlerine dahil oldum."
            },
            Skills = new() { "Python", "Django", "Django REST Framework", "Django ORM", "Git", "Kod inceleme" }
        }
    };

    // ── Projeler ──────────────────────────────────────────────────────────
    public static List<Project> AllProjects => new()
    {
        new Project
        {
            // Kaynak kod şirkete ait olduğu için depo veya demo bağlantısı verilmez.
            Slug = "presales-ai",
            Name = "Presales AI",
            Tagline = "Yapay Zekâ Destekli Teknik Şartname Analiz Sistemi",
            Summary = "Teknik şartname PDF'lerini LLM ile analiz edip farklı üreticilerin ürünlerini karşılaştıran, uyumluluk puanı hesaplayan karar destek uygulaması.",
            Type = "Staj Projesi",
            Featured = true,
            Role = "Ekspa Bilgisayar stajı",
            TeamSize = 2,
            CoverImage = "/images/projects/presales-ai.svg",
            CoverAlt = "Presales AI için şartname maddelerinin ürünlerle karşılaştırıldığı temsilî kapak görseli",
            Problem = "Satış öncesi ekipler, ihalelerdeki teknik şartnameleri madde madde okuyup farklı üreticilerin ürünleriyle elle karşılaştırır; bu süreç uzun sürer ve zorunlu bir kriterin gözden kaçması teklifin elenmesine yol açabilir.",
            Solution = "Şartname PDF'ini okuyup maddelerini kategorilere ayıran, ürün kriterlerini büyük dil modeliyle düzenlenebilir biçimde çıkaran ve farklı üreticilerin ürünlerini bu kriterlere göre karşılaştıran bir karar destek uygulaması.",
            Tech = new() { "React", "Django REST Framework", "PostgreSQL", "Groq API", "LLM", "Docker" },
            Contributions = new()
            {
                "Şartname maddelerinin ayrıştırılmasına ve teknik kriterlerin LLM ile çıkarılmasına katkı sağladım.",
                "Ürün uyumluluk puanlamasını ve zorunlu kriterlere göre elenme riski değerlendirmesini geliştirdim.",
                "Kaynak doğrulama, malzeme listesi (BOM) oluşturma, geçmiş kayıt yönetimi ve Excel'e aktarma özelliklerini ekledim."
            },
            SourceNote = "Bu proje şirket bünyesinde geliştirildiği için kaynak kodu paylaşılmamaktadır."
        },
        new Project
        {
            // TASLAK: Gerçek bilgileri yazıp IsDraft = false yapın.
            Slug = "parkpilot",
            Name = "ParkPilot",
            Tagline = "[Tek satırlık alt başlık]",
            Summary = "[Kartta görünecek kısa özet]",
            Type = "Ekip Projesi",
            Role = "[Rolün, örneğin Backend Geliştirici]",
            CoverImage = "/images/projects/parkpilot.svg",
            CoverAlt = "ParkPilot için otopark temalı kapak görseli",
            Problem = "[Projenin çözdüğü gerçek problem]",
            Solution = "[Sistemin ne yaptığı ve nasıl çalıştığı]",
            Tech = new() { "[Teknoloji]" },
            Contributions = new() { "[Senin yaptığın somut bir iş]" },
            IsDraft = true
        },
        new Project
        {
            // TASLAK: Gerçek bilgileri yazıp IsDraft = false yapın.
            Slug = "afet-pusulasi",
            Name = "Afet Pusulası",
            Tagline = "[Tek satırlık alt başlık]",
            Summary = "[Kartta görünecek kısa özet]",
            Type = "Ders Projesi",
            Status = "Geliştiriliyor",
            Role = "[Rolün]",
            CoverImage = "/images/projects/afet-pusulasi.svg",
            CoverAlt = "Afet Pusulası için harita ve toplanma noktası temalı kapak görseli",
            Problem = "[Projenin çözdüğü gerçek problem]",
            Solution = "[Sistemin ne yaptığı ve nasıl çalıştığı]",
            Tech = new() { "[Teknoloji]" },
            Contributions = new() { "[Senin yaptığın somut bir iş]" },
            IsDraft = true
        },
        new Project
        {
            Slug = "blog-project",
            Name = "Blog Project",
            Tagline = "Asenkron Görev Yönetimli Blog Platformu",
            Summary = "JWT kimlik doğrulamalı, çok kullanıcılı bir blog platformu; I/O yoğun işler Celery ve Redis ile arka planda çalışır.",
            CoverImage = "/images/projects/blog-project.svg",
            CoverAlt = "Blog Project için API isteği ve görev kuyruğu temalı kapak görseli",
            Problem = "E-posta bildirimi gibi I/O yoğun işlemler istek sırasında çalıştırıldığında kullanıcı yanıt için bu işlemlerin bitmesini bekler.",
            Solution = "Django ile JWT tabanlı kimlik doğrulamaya sahip, çok kullanıcılı bir blog platformu. Ağır işler Celery görev kuyruğuna, Redis aracılığıyla devredilir; periyodik işler Celery Beat ile zamanlanır.",
            Tech = new() { "Python", "Django", "DRF", "Celery", "Redis", "JWT", "PostgreSQL" },
            Contributions = new()
            {
                "Django ile JWT tabanlı kimlik doğrulamalı, çok kullanıcılı blog platformunu geliştirdim.",
                "E-posta bildirimi gibi I/O yoğun işlemleri Celery + Redis ile arka plana taşıdım.",
                "Celery Beat ile zamanlanmış görevler tanımlayarak periyodik bildirim gönderen bir modül kurdum."
            },
            Results = new() { "I/O yoğun işlemler arka plana taşındığı için HTTP yanıt süreleri düştü." },
            RepoUrl = "https://github.com/a1eynayildiz/blog_project"
        },
        new Project
        {
            Slug = "hastane-yonetim-sistemi",
            Name = "HastaneYonetimSistemi",
            Tagline = "Veritabanı Entegreli Hastane Yönetim Sistemi",
            Summary = "Hasta, doktor, bölüm ve randevu verilerini T-SQL ve ADO.NET ile güvenli biçimde yöneten çok formlu masaüstü uygulaması.",
            CoverImage = "/images/projects/hastane-yonetim-sistemi.svg",
            CoverAlt = "Hastane Yönetim Sistemi için veritabanı şeması temalı kapak görseli",
            Problem = "Hasta, doktor, bölüm ve randevu bilgilerinin birbiriyle tutarlı ve güvenli biçimde yönetilmesi gerekir.",
            Solution = "Bu ilişkileri modelleyen bir MSSQL veritabanı ve üzerine kurulu, çok formlu bir Windows Forms masaüstü uygulaması.",
            Tech = new() { "C#", ".NET", "Windows Forms", "MSSQL", "ADO.NET", "T-SQL" },
            Contributions = new()
            {
                "Hasta, doktor, bölüm ve randevu tablolarını modelledim.",
                "JOIN ve agregasyon içeren T-SQL sorgularıyla çok formlu masaüstü uygulamayı geliştirdim.",
                "ADO.NET parametreli sorgularla SQL Injection'a karşı güvenli veri erişimi sağladım."
            },
            RepoUrl = "https://github.com/a1eynayildiz/HastaneYonetimSistemi"
        },
        new Project
        {
            Slug = "taskmanager",
            Name = "TaskManager",
            Tagline = "Rol Tabanlı Görev Atama Sistemi",
            Summary = "Superuser, admin ve kullanıcı rolleriyle görev atayan Django uygulaması; PythonAnywhere üzerinde canlı yayında.",
            Status = "Canlı",
            CoverImage = "/images/projects/taskmanager.svg",
            CoverAlt = "TaskManager için görev panosu temalı kapak görseli",
            Problem = "Bir ekipte herkesin yalnızca yetkisi olan görevleri görmesi ve atayabilmesi gerekir.",
            Solution = "Django ile geliştirilmiş, rol bazlı (superuser / admin / user) görev atama uygulaması. Superuser tüm görevleri görüp herkese atama yapabilir, admin kendi görevlerini görüp kullanıcılara atama yapabilir, kullanıcılar yalnızca kendi görevlerini görüntüleyebilir.",
            Tech = new() { "Python", "Django", "SQLite", "HTML", "Auth" },
            Contributions = new()
            {
                "Üç seviyeli rol ve yetki modelini Django'nun kimlik doğrulama sistemiyle kurdum.",
                "Uygulamayı PythonAnywhere üzerinde yayına aldım."
            },
            Results = new() { "PythonAnywhere üzerinde canlı yayında." },
            RepoUrl = "https://github.com/a1eynayildiz/taskmanager",
            DemoUrl = null // Canlı adresi buraya yazın; "Proje Linki" butonu otomatik görünür.
        },
        new Project
        {
            Slug = "aspnet-core-mvc-basics",
            Name = "ASP.NET Core MVC Basics",
            Tagline = "CRUD Operasyonları ile MVC Temelleri",
            Summary = "Controller, Model ve View yapısını; form işleme ve routing'i temel CRUD işlemleriyle uygulayan proje.",
            CoverImage = "/images/projects/aspnet-core-mvc-basics.svg",
            CoverAlt = "ASP.NET Core MVC Basics için MVC katmanları temalı kapak görseli",
            Solution = "ASP.NET Core MVC ile temel CRUD operasyonlarını uygulayan başlangıç seviyesi bir proje. Controller / Model / View yapısı, form işleme ve routing pratiği için hazırlandı.",
            Tech = new() { "C#", "ASP.NET Core", "MVC", "Razor", "CRUD" },
            RepoUrl = "https://github.com/a1eynayildiz/aspnet-core-mvc-basics"
        },
        new Project
        {
            Slug = "python-mini-projeler",
            Name = "Python Mini Projeler",
            Tagline = "Farklı Kütüphanelerle Küçük Ölçekli Uygulamalar",
            Summary = "YouTube indiriciden subdomain tarayıcısına, farklı Python kütüphaneleriyle hazırlanmış mini projeler.",
            CoverImage = "/images/projects/python-mini-projeler.svg",
            CoverAlt = "Python Mini Projeler için terminal temalı kapak görseli",
            Solution = "Çeşitli Python kütüphaneleriyle hazırlanmış mini projelerin toplandığı bir depo: YouTube indirici, PDF dönüştürücü, QR kod üretici, Secret Santa, arka plan silici, GIF üretici, Hacker News top 30, BMI hesaplayıcı, subdomain tarayıcısı ve daha fazlası.",
            Tech = new() { "Python", "Automation", "CLI", "Scripting" },
            RepoUrl = "https://github.com/a1eynayildiz/Python_Projects"
        }
    };

    // ── Başarılar ─────────────────────────────────────────────────────────
    public static List<Achievement> Achievements => new()
    {
        new Achievement
        {
            Kind = AchievementKind.Award,
            Title = "Girişimcilik Maratonu 2.'lik Ödülü",
            Issuer = "Düzce Teknopark",
            Description = "NeuroNova (epilepsi izleme cihazı) projesiyle ikincilik kazandık; literatür taraması, ürün adlandırması ve sistem pipeline tasarımına katkı sağladım."
        },
        new Achievement
        {
            Kind = AchievementKind.Publication,
            Title = "Teknik Blog Yazıları",
            Issuer = "Siber İz",
            Description = "Siber güvenlik ve web geliştirme alanlarında düzenli olarak teknik blog yazıları yayımladım."
            // Yazılarının adresini Url = "https://..." olarak ekleyebilirsin.
        },
        new Achievement
        {
            Kind = AchievementKind.Certificate,
            Title = "Her Yönüyle SQL Server",
            Issuer = "BTK Akademi"
        },
        new Achievement
        {
            Kind = AchievementKind.Certificate,
            Title = "Python 2025 (100 Günlük Kamp)",
            Issuer = "Udemy"
        },
        new Achievement
        {
            Kind = AchievementKind.Certificate,
            Title = "Veri Bilimi ve Makine Öğrenmesi 100 Günlük Kamp",
            Issuer = "Udemy",
            InProgress = true
        }
    };

    // ── Sayfada gösterilenler (taslaklar hariç) ───────────────────────────
    public static List<Project> Projects => AllProjects.Where(p => !p.IsDraft).ToList();
    public static List<Experience> Experiences => AllExperiences.Where(e => !e.IsDraft).ToList();
}
