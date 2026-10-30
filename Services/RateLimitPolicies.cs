namespace AleynaPortfolio.Services;

public static class RateLimitPolicies
{
    /// <summary>Aynı IP adresinden 10 dakikada en fazla 3 iletişim formu gönderimi.</summary>
    public const string Contact = "contact";
    public const int ContactPermitLimit = 3;
    public static readonly TimeSpan ContactWindow = TimeSpan.FromMinutes(10);
}
