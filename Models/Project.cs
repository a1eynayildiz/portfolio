namespace AleynaPortfolio.Models;

public class Project
{
    public string Name { get; set; } = string.Empty;
    public string Tagline { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string RepoUrl { get; set; } = string.Empty;
    public List<string> Tech { get; set; } = new();
}
