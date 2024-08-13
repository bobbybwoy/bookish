using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using bookish.Models;
using bookish.DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace bookish.Controllers;


public class BookController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly BookishContext _context;

    public BookController(ILogger<HomeController> logger, BookishContext context)
    {
        _logger = logger;
        _context = context;
    }


    public async Task<IActionResult> Index()
    { 
        return View(await _context.Books.ToListAsync());
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
