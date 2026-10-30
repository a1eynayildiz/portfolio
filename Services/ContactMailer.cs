using System.Net;
using System.Net.Mail;
using System.Text;
using AleynaPortfolio.Models;
using Microsoft.Extensions.Options;

namespace AleynaPortfolio.Services;

public interface IContactMailer
{
    bool IsConfigured { get; }
    Task SendAsync(ContactForm form, CancellationToken cancellationToken);
}

/// <summary>
/// İletişim formundaki mesajı SMTP ile e-posta kutusuna iletir.
/// Yanıtla (Reply-To) alanı ziyaretçinin adresidir; böylece e-postayı doğrudan yanıtlayabilirsiniz.
/// </summary>
public sealed class SmtpContactMailer : IContactMailer
{
    private readonly SmtpOptions _options;

    public SmtpContactMailer(IOptions<SmtpOptions> options) => _options = options.Value;

    public bool IsConfigured => _options.IsConfigured;

    public async Task SendAsync(ContactForm form, CancellationToken cancellationToken)
    {
        if (!IsConfigured)
            throw new InvalidOperationException("SMTP ayarları eksik.");

        using var message = new MailMessage
        {
            From = new MailAddress(_options.From!, "Portfolyo İletişim Formu"),
            Subject = $"[Portfolyo] {SingleLine(form.Subject)} – {SingleLine(form.Name)}",
            SubjectEncoding = Encoding.UTF8,
            BodyEncoding = Encoding.UTF8,
            IsBodyHtml = false,
            Body =
                $"Ad Soyad: {form.Name}\n" +
                $"E-posta: {form.Email}\n" +
                $"Konu: {form.Subject}\n\n" +
                $"{form.Message}\n"
        };
        message.To.Add(_options.To!);
        message.ReplyToList.Add(new MailAddress(form.Email, SingleLine(form.Name)));

        using var client = new SmtpClient(_options.Host!, _options.Port)
        {
            EnableSsl = _options.EnableSsl,
            DeliveryMethod = SmtpDeliveryMethod.Network
        };
        if (!string.IsNullOrWhiteSpace(_options.Username))
            client.Credentials = new NetworkCredential(_options.Username, _options.Password);

        await client.SendMailAsync(message, cancellationToken);
    }

    /// <summary>Başlık enjeksiyonunu önlemek için satır sonlarını kaldırır.</summary>
    private static string SingleLine(string value) =>
        value.Replace("\r", " ").Replace("\n", " ").Trim();
}
