using System.ComponentModel.DataAnnotations;

namespace AleynaPortfolio.Models;

public class ContactForm
{
    public static readonly string[] Subjects = { "Staj teklifi", "İş birliği", "Diğer" };

    [Required(ErrorMessage = "Lütfen adınızı ve soyadınızı yazın.")]
    [StringLength(80, MinimumLength = 2, ErrorMessage = "Ad soyad 2 ile 80 karakter arasında olmalıdır.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Lütfen e-posta adresinizi yazın.")]
    [EmailAddress(ErrorMessage = "Lütfen geçerli bir e-posta adresi girin.")]
    [StringLength(254, ErrorMessage = "E-posta adresi çok uzun.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Lütfen bir konu seçin.")]
    public string Subject { get; set; } = string.Empty;

    [Required(ErrorMessage = "Lütfen mesajınızı yazın.")]
    [StringLength(2000, MinimumLength = 10, ErrorMessage = "Mesaj 10 ile 2000 karakter arasında olmalıdır.")]
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// Görünmez tuzak alanı (honeypot). İnsanlar bu alanı görmez; dolu gelirse istek bir bottur.
    /// </summary>
    public string? Website { get; set; }
}
