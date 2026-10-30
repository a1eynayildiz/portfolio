namespace AleynaPortfolio.Models;

public class Experience
{
    public string Company { get; set; } = string.Empty;
    public string? CompanyUrl { get; set; }
    public string Role { get; set; } = string.Empty;
    public string Period { get; set; } = string.Empty;

    /// <summary>"Zorunlu Staj", "Gönüllü Staj", "Yarı Zamanlı" gibi.</summary>
    public string? Kind { get; set; }

    /// <summary>Şirketin ne yaptığı ve hangi ekipte çalışıldığı (tek cümle).</summary>
    public string? Context { get; set; }

    public List<string> Highlights { get; set; } = new();

    /// <summary>Kazanımlar; etiket olarak gösterilir.</summary>
    public List<string> Skills { get; set; } = new();

    /// <summary>true ise deneyim sitede gösterilmez.</summary>
    public bool IsDraft { get; set; }
}
