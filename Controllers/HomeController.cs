using AleynaPortfolio.Models;
using AleynaPortfolio.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace AleynaPortfolio.Controllers;

public class HomeController : Controller
{
    private const string FallbackMessage =
        "Mesajınız şu anda gönderilemedi. Lütfen doğrudan e-posta ile ulaşın: " + PortfolioData.Email;

    private readonly IContactMailer _mailer;
    private readonly IWebHostEnvironment _env;
    private readonly ILogger<HomeController> _logger;

    public HomeController(IContactMailer mailer, IWebHostEnvironment env, ILogger<HomeController> logger)
    {
        _mailer = mailer;
        _env = env;
        _logger = logger;
    }

    [HttpGet("/")]
    public IActionResult Index()
    {
        // Form, SMTP ayarlı olduğunda gösterilir. Geliştirme ortamında tasarımı görebilmek için her zaman gösterilir.
        ViewData["ContactEnabled"] = _mailer.IsConfigured || _env.IsDevelopment();
        return View();
    }

    // Eski çok sayfalı sürümün adresleri, tek sayfadaki ilgili bölüme yönlendirilir.
    [HttpGet("/Home/About")]
    public IActionResult About() => RedirectPermanent("/#hakkimda");

    [HttpGet("/Home/Projects")]
    public IActionResult Projects() => RedirectPermanent("/#projeler");

    [HttpGet("/Home/Index")]
    public IActionResult LegacyIndex() => RedirectPermanent("/");

    [HttpPost("/iletisim")]
    [ValidateAntiForgeryToken]
    [EnableRateLimiting(RateLimitPolicies.Contact)]
    public async Task<IActionResult> Contact([FromForm] ContactForm form, CancellationToken cancellationToken)
    {
        // Tuzak alanı doluysa istek bir bottur: başarılıymış gibi yanıt verip hiçbir şey göndermeyiz.
        if (!string.IsNullOrEmpty(form.Website))
            return ContactResult(StatusCodes.Status200OK, true, SuccessMessage);

        if (!ContactForm.Subjects.Contains(form.Subject))
            ModelState.AddModelError(nameof(ContactForm.Subject), "Lütfen listeden bir konu seçin.");

        if (!ModelState.IsValid)
        {
            var errors = ModelState
                .Where(kv => kv.Value?.Errors.Count > 0)
                .ToDictionary(
                    kv => char.ToLowerInvariant(kv.Key[0]) + kv.Key[1..],
                    kv => kv.Value!.Errors[0].ErrorMessage);
            return ContactResult(StatusCodes.Status400BadRequest, false,
                "Lütfen işaretli alanları kontrol edin.", errors);
        }

        if (!_mailer.IsConfigured)
            return ContactResult(StatusCodes.Status503ServiceUnavailable, false, FallbackMessage);

        try
        {
            await _mailer.SendAsync(form, cancellationToken);
            return ContactResult(StatusCodes.Status200OK, true, SuccessMessage);
        }
        catch (Exception ex)
        {
            // Mesajın içeriği kişisel veri olduğu için günlüğe yazılmaz.
            _logger.LogError(ex, "İletişim formu e-postası gönderilemedi.");
            return ContactResult(StatusCodes.Status502BadGateway, false, FallbackMessage);
        }
    }

    [Route("/Home/Error")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() => View();

    private const string SuccessMessage = "Mesajınız ulaştı, en kısa sürede dönüş yapacağım.";

    /// <summary>
    /// JavaScript ile gönderilen isteklere JSON döner. JavaScript kapalıysa form normal biçimde
    /// gönderilir; bu durumda sonuç mesajıyla birlikte iletişim bölümüne geri yönlendirilir.
    /// </summary>
    private IActionResult ContactResult(int status, bool ok, string message,
        Dictionary<string, string>? errors = null)
    {
        if (Request.Headers.Accept.Any(a => a?.Contains("application/json") == true))
            return StatusCode(status, new { ok, message, errors });

        TempData["ContactOk"] = ok;
        TempData["ContactMessage"] = message;
        return Redirect("/#iletisim");
    }
}
