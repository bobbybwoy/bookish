using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using bookish.Models;
using bookish.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Npgsql;
//using Microsoft.AspNetCore.Http;

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
        return View(await _context.Books.OrderBy(book => book.Id).ToListAsync());
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult MyPage()
    {
        return View();
    }

    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            ViewBag.Message = "Id missing from request";
            return View("Error");   
        }
        BookViewModel? book = _context.Books.Find(id);
        if (book == null)
        {
            ViewBag.Message = "Book not found";
            return View("Error");
        }
        return View(book);
    }

    [HttpGet]
    public ActionResult AddBook()
    {
        return View();
    }

    [HttpPost]
    public ActionResult AddBook(BookViewModel book)
    {
        if (ModelState.IsValid)
        {
            // string connectionString = "Server=localhost;Port=5432;Database=bookish;User Id=bookish;Password=bookish;";
            // string insertQuery = "INSERT INTO Books(BookId, Title, Author, Description) VALUES(@BookId, @Title, @Author, @Description)";



            // using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            // {
            //     NpgsqlCommand command = new NpgsqlCommand(insertQuery, connection);
            //     command.Parameters.AddWithValue("@BookId", book.BookId);
            //     command.Parameters.AddWithValue("@Title", book.Title);
            //     command.Parameters.AddWithValue("@Author", book.Author);
            //     command.Parameters.AddWithValue("@Description", book.Description);

            //     connection.Open();
            //     command.ExecuteNonQuery();
            // }

            _context.Books.Add(book);
            _context.SaveChanges();


            ViewBag.Message = "Employee data inserted successfully.";

        }
        else
        {
            ViewBag.Message = "There are some errors on the page.";
            return View(book);
        }
        return View();
    }

    [HttpGet]
    public ActionResult UpdateDescription(int? id)
    {
        if (id == null)
        {
            // TODO: Add more meaningful error handling.
            // return RedirectToAction("Error");
            ViewBag.Message = "Id missing from request";
            return View("Error");
        }
        BookViewModel? book = _context.Books.Find(id);
        if (book == null)
        {
            ViewBag.Message = "Book not found";
            return View("Error");
        }
        return View(book);
    }

    [HttpPost]
    public ActionResult UpdateDescription(int? id, string description)
    {
        // ViewBag.Message = "";
        if (id == null)
        {
            ViewBag.Message = "Id missing from request";
            return View("Error");
        }
        BookViewModel? book = _context.Books.Find(id);
        if (book == null)
        {
            ViewBag.Message = "Book not found";
            return View("Error");
        }
        book.Description = description;
        _context.Books.Update(book);
        _context.SaveChanges();

        return RedirectToAction("Details", new { id = id });
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
