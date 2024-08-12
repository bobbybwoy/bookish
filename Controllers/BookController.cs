using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using bookish.Models;

namespace bookish.Controllers;


public class BookController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public BookController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }


    public IActionResult Index()
    {
        BookViewModel bookModel = new BookViewModel { Author = "Anum", BookId = 1, Description = "We are learning...", Title = "How Does This Work?"};
        ViewData["Book"] = bookModel;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult MyPage()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
