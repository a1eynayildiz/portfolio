using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using AleynaPortfolio.Models;
using Microsoft.Extensions.Options;

namespace AleynaPortfolio.Services;

/// <summary>
/// "Resend" bölümü veya ortam değişkenleri: Resend__ApiKey (zorunlu), Resend__To, Resend__From.
/// API anahtarı asla depoya yazılmaz; barındırma ortamında ortam değişkeni olarak tanımlanır.
/// </summary>
public class ResendOptions
{
    public const string SectionName = "Resend";

    public string? ApiKey { get; set; }

    /// <summary>
    /// Mesajların ulaşacağı adres. Boşsa sitedeki e-posta adresi kullanılır.
    /// Kendi alan adınızı doğrulamadıysanız bu adres Resend hesabınızın e-postasıyla aynı olmalıdır.
    /// </summary>
    public string? To { get; set; }

    /// <summary>Gönderen adres. Alan adı doğrulanmadıysa Resend'in test adresi kullanılır.</summary>
    public string From { get; set; } = "Portfolyo İletişim Formu <onboarding@resend.dev>";

    public bool IsConfigured => !string.IsNullOrWhiteSpace(ApiKey);
}

/// <summary>
/// İletişim formundaki mesajı Resend'in HTTPS API'si ile iletir. SMTP portlarını kullanmadığı için
/// bu portların kapalı olduğu barındırma ortamlarında (örneğin Render'ın ücretsiz planı) da çalışır.
/// Yanıtla (Reply-To) alanı ziyaretçinin adresidir; e-postayı doğrudan yanıtlayabilirsiniz.
/// </summary>
public sealed class ResendContactMailer : IContactMailer
{
    public const string HttpClientName = "resend";

    private readonly ResendOptions _options;
    private readonly IHttpClientFactory _httpClientFactory;

    public ResendContactMailer(IOptions<ResendOptions> options, IHttpClientFactory httpClientFactory)
    {
        _options = options.Value;
        _httpClientFactory = httpClientFactory;
    }

    public bool IsConfigured => _options.IsConfigured;

    public async Task SendAsync(ContactForm form, CancellationToken cancellationToken)
    {
        if (!IsConfigured)
            throw new InvalidOperationException("Resend API anahtarı tanımlı değil.");

        var to = string.IsNullOrWhiteSpace(_options.To) ? PortfolioData.Email : _options.To!;

        var payload = new ResendEmail(
            From: _options.From,
            To: new[] { to },
            ReplyTo: form.Email,
            Subject: $"[Portfolyo] {SingleLine(form.Subject)} – {SingleLine(form.Name)}",
            Text:
                $"Ad Soyad: {form.Name}\n" +
                $"E-posta: {form.Email}\n" +
                $"Konu: {form.Subject}\n\n" +
                $"{form.Message}\n");

        var client = _httpClientFactory.CreateClient(HttpClientName);
        using var request = new HttpRequestMessage(HttpMethod.Post, "emails")
        {
            Content = JsonContent.Create(payload)
        };
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _options.ApiKey);

        using var response = await client.SendAsync(request, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            // Yanıt gövdesi Resend'in hata açıklamasını içerir (örneğin geçersiz anahtar); mesaj içeriği içermez.
            var detail = await response.Content.ReadAsStringAsync(cancellationToken);
            throw new HttpRequestException(
                $"Resend {(int)response.StatusCode} döndürdü: {detail}", null, response.StatusCode);
        }
    }

    /// <summary>Konu satırında satır sonlarını kaldırır.</summary>
    private static string SingleLine(string value) =>
        value.Replace("\r", " ").Replace("\n", " ").Trim();

    private sealed record ResendEmail(
        [property: JsonPropertyName("from")] string From,
        [property: JsonPropertyName("to")] string[] To,
        [property: JsonPropertyName("reply_to")] string ReplyTo,
        [property: JsonPropertyName("subject")] string Subject,
        [property: JsonPropertyName("text")] string Text);
}
