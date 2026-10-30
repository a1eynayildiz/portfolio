namespace AleynaPortfolio.Models;

public enum AchievementKind
{
    Award,
    Certificate,
    Publication,
    Program
}

public class Achievement
{
    public AchievementKind Kind { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string? Date { get; set; }
    public string? Description { get; set; }
    public string? Url { get; set; }
    public bool InProgress { get; set; }

    public string KindLabel => Kind switch
    {
        AchievementKind.Award => "Ödül",
        AchievementKind.Certificate => "Sertifika",
        AchievementKind.Publication => "Yayın",
        AchievementKind.Program => "Program",
        _ => string.Empty
    };
}
