namespace AleynaPortfolio.Models;

public class Experience
{
    public string Company { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string Period { get; set; } = string.Empty;
    public List<string> Highlights { get; set; } = new();
}
