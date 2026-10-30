namespace AleynaPortfolio.Models;

/// <summary>
/// Projelerim bölümündeki bir kart ve ona bağlı detay paneli.
/// Boş bırakılan isteğe bağlı alanlar (Problem, Role, DemoUrl vb.) sayfada gösterilmez.
/// </summary>
public class Project
{
    /// <summary>Adres için kısa ad: "parkpilot" → #projeler/parkpilot</summary>
    public string Slug { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    /// <summary>Kartta görünen tek satırlık alt başlık.</summary>
    public string Tagline { get; set; } = string.Empty;

    /// <summary>Kartta görünen kısa özet (en fazla iki satır).</summary>
    public string Summary { get; set; } = string.Empty;

    /// <summary>"Kişisel", "Ders Projesi", "Ekip Projesi". Boşsa rozet gösterilmez.</summary>
    public string? Type { get; set; }

    /// <summary>"Canlı", "Tamamlandı", "Geliştiriliyor". Boşsa rozet gösterilmez.</summary>
    public string? Status { get; set; }

    public string? Role { get; set; }
    public string? Duration { get; set; }
    public int? TeamSize { get; set; }

    /// <summary>Öne çıkan proje: masaüstünde iki sütunu kaplayan geniş kart.</summary>
    public bool Featured { get; set; }

    /// <summary>true ise proje sitede gösterilmez; bilgiler tamamlanınca false yapın.</summary>
    public bool IsDraft { get; set; }

    /// <summary>wwwroot altındaki kapak görseli, örneğin "/images/projects/parkpilot.svg".</summary>
    public string CoverImage { get; set; } = string.Empty;
    public string CoverAlt { get; set; } = string.Empty;

    public string? Problem { get; set; }
    public string Solution { get; set; } = string.Empty;
    public List<string> Tech { get; set; } = new();
    public List<string> Contributions { get; set; } = new();

    /// <summary>Ölçülebilir sonuçlar. Henüz sonuç yoksa boş bırakın.</summary>
    public List<string> Results { get; set; } = new();

    public string? RepoUrl { get; set; }
    public string? DemoUrl { get; set; }

    /// <summary>Bağlantı verilmeyen projelerde gösterilecek açıklama (örneğin şirket içi projeler).</summary>
    public string? SourceNote { get; set; }

    /// <summary>Detay panelinde künye olarak gösterilen bilgiler.</summary>
    public IEnumerable<(string Label, string Value)> Facts
    {
        get
        {
            if (!string.IsNullOrWhiteSpace(Type)) yield return ("Tür", Type!);
            if (!string.IsNullOrWhiteSpace(Role)) yield return ("Rol", Role!);
            if (!string.IsNullOrWhiteSpace(Duration)) yield return ("Süre", Duration!);
            if (TeamSize is > 1) yield return ("Ekip", $"{TeamSize} kişi");
            if (!string.IsNullOrWhiteSpace(Status)) yield return ("Durum", Status!);
        }
    }
}
