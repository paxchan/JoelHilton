using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using JoelHiltonMovies.Models;

namespace JoelHiltonMovies.Controllers;

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

    public IActionResult GetToKnowJoel()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Movies()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Movies(Movie response)
    {
        return View("Confirmation");
    }
}