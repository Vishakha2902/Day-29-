using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StudentApp.Filters;
using StudentApp.Models;

namespace StudentApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [ServiceFilter(typeof(CustomAuthorizationFilter))]
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [ServiceFilter(typeof(CustomAuthorizationFilter))]
    public IActionResult Secret()
    {
        return Content("This is a secret message.");
    }
}
