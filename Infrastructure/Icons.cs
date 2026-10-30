using Microsoft.AspNetCore.Html;

namespace AleynaPortfolio.Infrastructure;

/// <summary>
/// Lucide simge setinden (ISC lisansı, lucide.dev) seçilmiş satır içi SVG simgeler.
/// Harici bir kütüphane yüklemeden tek tip ve hafif simgeler sağlar.
/// </summary>
public static class Icons
{
    private static readonly Dictionary<string, string> Paths = new()
    {
        ["github"] = "<path d=\"M15 22v-4a4.8 4.8 0 0 0-1-3.5c3 0 6-2 6-5.5.08-1.25-.27-2.48-1-3.5.28-1.15.28-2.35 0-3.5 0 0-1 0-3 1.5-2.64-.5-5.36-.5-8 0C6 2 5 2 5 2c-.3 1.15-.3 2.35 0 3.5A5.403 5.403 0 0 0 4 9c0 3.5 3 5.5 6 5.5-.39.49-.68 1.05-.85 1.65-.17.6-.22 1.23-.15 1.85v4\"/><path d=\"M9 18c-4.51 2-5-2-7-2\"/>",
        ["linkedin"] = "<path d=\"M16 8a6 6 0 0 1 6 6v7h-4v-7a2 2 0 0 0-2-2 2 2 0 0 0-2 2v7h-4v-7a6 6 0 0 1 6-6z\"/><rect width=\"4\" height=\"12\" x=\"2\" y=\"9\"/><circle cx=\"4\" cy=\"4\" r=\"2\"/>",
        ["mail"] = "<rect width=\"20\" height=\"16\" x=\"2\" y=\"4\" rx=\"2\"/><path d=\"m22 7-8.97 5.7a1.94 1.94 0 0 1-2.06 0L2 7\"/>",
        ["pen"] = "<path d=\"M12 20h9\"/><path d=\"M16.376 3.622a1 1 0 0 1 3.002 3.002L7.368 18.635a2 2 0 0 1-.855.506l-2.872.838a.5.5 0 0 1-.62-.62l.838-2.872a2 2 0 0 1 .506-.854z\"/>",
        ["map-pin"] = "<path d=\"M20 10c0 4.993-5.539 10.193-7.399 11.799a1 1 0 0 1-1.202 0C9.539 20.193 4 14.993 4 10a8 8 0 0 1 16 0\"/><circle cx=\"12\" cy=\"10\" r=\"3\"/>",
        ["sun"] = "<circle cx=\"12\" cy=\"12\" r=\"4\"/><path d=\"M12 2v2\"/><path d=\"M12 20v2\"/><path d=\"m4.93 4.93 1.41 1.41\"/><path d=\"m17.66 17.66 1.41 1.41\"/><path d=\"M2 12h2\"/><path d=\"M20 12h2\"/><path d=\"m6.34 17.66-1.41 1.41\"/><path d=\"m19.07 4.93-1.41 1.41\"/>",
        ["moon"] = "<path d=\"M12 3a6 6 0 0 0 9 9 9 9 0 1 1-9-9Z\"/>",
        ["menu"] = "<path d=\"M4 6h16\"/><path d=\"M4 12h16\"/><path d=\"M4 18h16\"/>",
        ["x"] = "<path d=\"M18 6 6 18\"/><path d=\"m6 6 12 12\"/>",
        ["arrow-up-right"] = "<path d=\"M7 7h10v10\"/><path d=\"M7 17 17 7\"/>",
        ["arrow-right"] = "<path d=\"M5 12h14\"/><path d=\"m12 5 7 7-7 7\"/>",
        ["arrow-down"] = "<path d=\"M12 5v14\"/><path d=\"m19 12-7 7-7-7\"/>",
        ["arrow-up"] = "<path d=\"m5 12 7-7 7 7\"/><path d=\"M12 19V5\"/>",
        ["download"] = "<path d=\"M21 15v4a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2v-4\"/><path d=\"m7 10 5 5 5-5\"/><path d=\"M12 15V3\"/>",
        ["copy"] = "<rect width=\"14\" height=\"14\" x=\"8\" y=\"8\" rx=\"2\" ry=\"2\"/><path d=\"M4 16c-1.1 0-2-.9-2-2V4c0-1.1.9-2 2-2h10c1.1 0 2 .9 2 2\"/>",
        ["check"] = "<path d=\"M20 6 9 17l-5-5\"/>",
        ["award"] = "<path d=\"m15.477 12.89 1.515 8.526a.5.5 0 0 1-.81.47l-3.58-2.687a1 1 0 0 0-1.197 0l-3.586 2.686a.5.5 0 0 1-.81-.469l1.514-8.526\"/><circle cx=\"12\" cy=\"8\" r=\"6\"/>",
        ["certificate"] = "<circle cx=\"12\" cy=\"12\" r=\"10\"/><path d=\"m9 12 2 2 4-4\"/>",
        ["book-open"] = "<path d=\"M12 7v14\"/><path d=\"M3 18a1 1 0 0 1-1-1V4a1 1 0 0 1 1-1h5a4 4 0 0 1 4 4 4 4 0 0 1 4-4h5a1 1 0 0 1 1 1v13a1 1 0 0 1-1 1h-6a3 3 0 0 0-3 3 3 3 0 0 0-3-3z\"/>",
        ["rocket"] = "<path d=\"M4.5 16.5c-1.5 1.26-2 5-2 5s3.74-.5 5-2c.71-.84.7-2.13-.09-2.91a2.18 2.18 0 0 0-2.91-.09z\"/><path d=\"m12 15-3-3a22 22 0 0 1 2-3.95A12.88 12.88 0 0 1 22 2c0 2.72-.78 7.5-6 11a22.35 22.35 0 0 1-4 2z\"/><path d=\"M9 12H4s.55-3.03 2-4c1.62-1.08 5 0 5 0\"/><path d=\"M12 15v5s3.03-.55 4-2c1.08-1.62 0-5 0-5\"/>"
    };

    public static IHtmlContent Get(string name, int size = 20, string? cssClass = null)
    {
        if (!Paths.TryGetValue(name, out var paths))
            throw new ArgumentException($"Bilinmeyen simge: {name}", nameof(name));

        var cls = cssClass is null ? "icon" : $"icon {cssClass}";
        return new HtmlString(
            $"<svg class=\"{cls}\" xmlns=\"http://www.w3.org/2000/svg\" width=\"{size}\" height=\"{size}\" " +
            "viewBox=\"0 0 24 24\" fill=\"none\" stroke=\"currentColor\" stroke-width=\"1.75\" " +
            $"stroke-linecap=\"round\" stroke-linejoin=\"round\" aria-hidden=\"true\" focusable=\"false\">{paths}</svg>");
    }

    public static string ForAchievement(Models.AchievementKind kind) => kind switch
    {
        Models.AchievementKind.Award => "award",
        Models.AchievementKind.Certificate => "certificate",
        Models.AchievementKind.Publication => "book-open",
        Models.AchievementKind.Program => "rocket",
        _ => "award"
    };
}
