namespace AleynaPortfolio.Models;

public static class PortfolioData
{
    public const string FullName = "Aleyna Yıldız";
    public const string Title = "Back-End Geliştirici";
    public const string Location = "İstanbul, Büyükçekmece";
    public const string Email = "aleynayildizc@gmail.com";
    public const string Github = "https://github.com/a1eynayildiz";
    public const string LinkedIn = "https://linkedin.com/in/aleynayildiz1";
    public const string Medium = "https://medium.com/@aleynayildizz";

    public const string About =
        "\"Bu neden böyle çalışıyor?\" sorusunun peşinden gitmeyi, backend tarafında " +
        "üretim ortamına dokunan işler yapmayı seven bir bilgisayar mühendisliği son sınıf " +
        "öğrencisiyim. Son deneyimlerimde PowerGIS'te C# ve PostgreSQL ile çok katmanlı bir " +
        "CBS uygulamasının veri yükleme ve form yapılandırma modüllerini geliştirdim; öncesinde " +
        "Django tarafında REST API tasarımı ve Celery + Redis ile asenkron görev yönetimi " +
        "üzerine çalıştım. Siber İz platformunda siber güvenlik ve web geliştirme alanlarında " +
        "düzenli olarak teknik blog yazıları yayımladım. Düzce Üniversitesi Kariyer Topluluğu - " +
        "Finans Departmanı üyesi olarak bütçe planlaması ve etkinlik gelir-gider tablolarının " +
        "hazırlanmasında görev aldım.";

    public static List<Experience> Experiences => new()
    {
        new Experience
        {
            Company = "PowerGIS",
            Role = "Backend Geliştirici",
            Period = "Mayıs 2026 — Haziran 2026",
            Highlights = new List<string>
            {
                "Veri erişim ve arayüz katmanını ayrı class library projelerine ayırarak çok katmanlı mimariye geçirdim; modüller arası bağımlılığı azaltarak kod tekrarını düşürdüm ve test edilebilirliği artırdım.",
                "Excel dosyalarını OleDb ile okuyup parametreli SQL sorgularıyla PostgreSQL'e aktaran ETL modülünü geliştirdim; dinamik kolon eşleştirme arayüzü sayesinde farklı şablondaki dosyalar tek modülle işlenebilir hale geldi.",
                "Çok sekmeli yapılandırma ekranları, DataGridView tabanlı görüntüleme formları ve dosya yükleme arayüzleri dahil birden fazla Windows Forms ekranı tasarlayarak son kullanıcının çok adımlı veri girişini tek arayüzde topladım."
            }
        },
        new Experience
        {
            Company = "GETAP",
            Role = "Yazılım Geliştirme Stajyeri",
            Period = "Haziran 2025 — Ağustos 2025",
            Highlights = new List<string>
            {
                "İki farklı Django web uygulamasının backend tarafında aktif rol alarak canlıya çıkan özelliklere doğrudan katkı sağladım.",
                "Django REST Framework ile RESTful API endpoint'leri tasarladım; serializer ve view katmanlarını geliştirerek frontend ekibinin ihtiyaç duyduğu veri sözleşmelerini netleştirdim.",
                "Django ORM ile ilişkisel veritabanı şemasını modelleyerek dinamik içerikli sayfaların üretimini sağladım; Git tabanlı akışta düzenli kod inceleme süreçlerine dahil oldum."
            }
        }
    };

    public static List<Project> Projects => new()
    {
        new Project
        {
            Name = "HastaneYonetimSistemi",
            Tagline = "Veritabanı Entegreli Hastane Yönetim Sistemi",
            Description = "Hasta, doktor, bölüm ve randevu tablolarını modelleyip JOIN ve agregasyon içeren T-SQL sorgularıyla çok formlu masaüstü uygulaması geliştirdim; ADO.NET parametreli sorgularla SQL Injection'a karşı güvenli veri erişimi sağladım.",
            RepoUrl = "https://github.com/a1eynayildiz/HastaneYonetimSistemi",
            Tech = new List<string> { "C#", ".NET", "Windows Forms", "MSSQL", "ADO.NET", "T-SQL" }
        },
        new Project
        {
            Name = "Blog Project",
            Tagline = "Asenkron Görev Yönetimli Blog Platformu",
            Description = "Django ile JWT tabanlı kimlik doğrulama ile çok kullanıcılı blog platformu geliştirdim; e-posta bildirimi gibi I/O yoğun işlemleri Celery + Redis ile arka plana taşıyarak HTTP yanıt sürelerini düşürdüm. Celery Beat ile zamanlanmış görevler tanımlayarak periyodik bildirim gönderen bir modül kurdum.",
            RepoUrl = "https://github.com/a1eynayildiz/blog_project",
            Tech = new List<string> { "Python", "Django", "DRF", "Celery", "Redis", "JWT", "PostgreSQL" }
        },
        new Project
        {
            Name = "TaskManager",
            Tagline = "Rol Tabanlı Görev Atama Sistemi",
            Description = "Django ile geliştirilmiş, rol bazlı (superuser / admin / user) görev atama uygulaması. Superuser tüm görevleri görüp herkese atama yapabilir, admin kendi görevlerini görüp kullanıcılara atama yapabilir, kullanıcılar yalnızca kendi görevlerini görüntüleyebilir. PythonAnywhere üzerinde canlı yayında.",
            RepoUrl = "https://github.com/a1eynayildiz/taskmanager",
            Tech = new List<string> { "Python", "Django", "SQLite", "HTML", "Auth" }
        },
        new Project
        {
            Name = "ASP.NET Core MVC Basics",
            Tagline = "CRUD Operasyonları ile MVC Temelleri",
            Description = "ASP.NET Core MVC ile temel CRUD operasyonlarını uygulayan başlangıç seviyesi bir proje. Controller / Model / View yapısı, form işleme ve routing pratiği için hazırlandı.",
            RepoUrl = "https://github.com/a1eynayildiz/aspnet-core-mvc-basics",
            Tech = new List<string> { "C#", "ASP.NET Core", "MVC", "Razor", "CRUD" }
        },
        new Project
        {
            Name = "Python Mini Projeler",
            Tagline = "Farklı Kütüphanelerle Küçük Ölçekli Uygulamalar",
            Description = "Çeşitli Python kütüphaneleriyle hazırlanmış mini projelerin toplandığı bir depo: YouTube indirici, PDF dönüştürücü, QR kod üretici, Secret Santa, arka plan silici, GIF üretici, Hacker News top 30, BMI hesaplayıcı, subdomain tarayıcısı ve daha fazlası.",
            RepoUrl = "https://github.com/a1eynayildiz/Python_Projects",
            Tech = new List<string> { "Python", "Automation", "CLI", "Scripting" }
        }
    };

    public static Dictionary<string, List<string>> Skills => new()
    {
        ["Diller & Backend"] = new() { "C#", ".NET", "ASP.NET", "SQL", "Windows Forms", "Python", "Django REST Framework" },
        ["Veritabanı"] = new() { "PostgreSQL", "MSSQL" },
        ["Araçlar"] = new() { "Git", "GitHub", "Postman", "Redis", "Celery", "JWT" },
        ["Yabancı Dil"] = new() { "Türkçe (Anadil)", "İngilizce (B1+)" }
    };

    public static List<string> Achievements => new()
    {
        "Düzce Teknopark Girişimcilik Maratonu — NeuroNova (epilepsi izleme cihazı) projesiyle 2.'lik ödülü; literatür taraması, ürün adlandırması ve sistem pipeline tasarımına katkı sağladım.",
        "Udemy — Python 2025 (100 Günlük Kamp)",
        "BTK Akademi — Her Yönüyle SQL Server",
        "Udemy — Veri Bilimi ve Makine Öğrenmesi 100 Günlük Kamp (devam ediyor)"
    };

    public const string EducationSchool = "Düzce Üniversitesi";
    public const string EducationProgram = "Bilgisayar Mühendisliği (Lisans)";
    public const string EducationPeriod = "2023 — 2027";
    public const string EducationGpa = "3.15 / 4.00";
}
