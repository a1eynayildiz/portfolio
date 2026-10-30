using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.RateLimiting;
using AleynaPortfolio.Services;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.WebEncoders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Türkçe karakterlerin (ç, ğ, ı, ö, ş, ü) HTML'de &#x131; gibi kodlanmadan, olduğu gibi yazılması için.
builder.Services.Configure<WebEncoderOptions>(options =>
    options.TextEncoderSettings = new TextEncoderSettings(UnicodeRanges.All));

// İletişim formu: Resend API anahtarı tanımlıysa Resend (HTTPS) kullanılır; değilse SMTP ayarlarına bakılır.
// Render'ın ücretsiz planında SMTP portları kapalı olduğu için orada Resend gerekir.
builder.Services.Configure<SmtpOptions>(builder.Configuration.GetSection(SmtpOptions.SectionName));
builder.Services.Configure<ResendOptions>(builder.Configuration.GetSection(ResendOptions.SectionName));
builder.Services.AddHttpClient(ResendContactMailer.HttpClientName, client =>
{
    client.BaseAddress = new Uri("https://api.resend.com/");
    client.Timeout = TimeSpan.FromSeconds(15);
});
builder.Services.AddSingleton<SmtpContactMailer>();
builder.Services.AddSingleton<ResendContactMailer>();
builder.Services.AddSingleton<IContactMailer>(sp =>
{
    var resend = sp.GetRequiredService<ResendContactMailer>();
    return resend.IsConfigured ? resend : sp.GetRequiredService<SmtpContactMailer>();
});

builder.Services.AddRateLimiter(options =>
{
    options.AddPolicy(RateLimitPolicies.Contact, context =>
        RateLimitPartition.GetFixedWindowLimiter(
            context.Connection.RemoteIpAddress?.ToString() ?? "unknown",
            _ => new FixedWindowRateLimiterOptions
            {
                PermitLimit = RateLimitPolicies.ContactPermitLimit,
                Window = RateLimitPolicies.ContactWindow,
                QueueLimit = 0
            }));

    options.OnRejected = async (context, cancellationToken) =>
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;
        await context.HttpContext.Response.WriteAsJsonAsync(new
        {
            ok = false,
            message = "Kısa sürede çok fazla mesaj gönderildi. Lütfen birkaç dakika sonra tekrar deneyin."
        }, cancellationToken);
    };
});

// Render gibi ters vekil sunucuların arkasında gerçek istemci IP'si ve HTTPS bilgisi için.
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
});

var app = builder.Build();
app.UseForwardedHeaders();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseRateLimiter();
app.UseAuthorization();
app.MapControllers();
app.Run();
