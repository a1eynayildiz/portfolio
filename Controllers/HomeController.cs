using AleynaPortfolio.Models;
using Microsoft.AspNetCore.Mvc;

namespace AleynaPortfolio.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View();

    public IActionResult About() => View();

    public IActionResult Projects()
    {
        return View(PortfolioData.Projects);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() => View();
}
