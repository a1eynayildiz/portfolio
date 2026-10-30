namespace AleynaPortfolio.Services;

/// <summary>
/// appsettings.json içindeki "Smtp" bölümü veya ortam değişkenleri
/// (Smtp__Host, Smtp__Port, Smtp__Username, Smtp__Password, Smtp__From, Smtp__To).
/// Şifre asla depoya yazılmaz; Render'da ortam değişkeni olarak tanımlanır.
/// </summary>
public class SmtpOptions
{
    public const string SectionName = "Smtp";

    public string? Host { get; set; }
    public int Port { get; set; } = 587;
    public bool EnableSsl { get; set; } = true;
    public string? Username { get; set; }
    public string? Password { get; set; }

    /// <summary>Gönderen adres. Gmail'de giriş yapılan hesapla aynı olmalıdır.</summary>
    public string? From { get; set; }

    /// <summary>Mesajların ulaşacağı adres.</summary>
    public string? To { get; set; }

    public bool IsConfigured =>
        !string.IsNullOrWhiteSpace(Host) &&
        !string.IsNullOrWhiteSpace(From) &&
        !string.IsNullOrWhiteSpace(To);
}
