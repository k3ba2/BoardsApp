using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using kursmvc.MVC.Models;

namespace kursmvc.MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        var model = new List<Person>()
        {
            new Person()
            {
                FirstName = "Jakub",
                LastName = "Test"
            },
            new Person()
            {
                FirstName = "Adam",
                LastName = "Test"
            },
        };
        return View(model);
    }

    public IActionResult About()
    {
        var model = new List<AboutModel>
        {
            new AboutModel() 
            {
            Title = "test about",
            Description = "description about",
            Tags = "test tags"
            }
        };

        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
