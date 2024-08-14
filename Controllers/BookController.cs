using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using bookish.Models;
using bookish.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Microsoft.AspNetCore.Http;

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

    public ActionResult Details(int? id)
    {
        int statusCode = 0;
        if (id == null)
        {
            //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            statusCode =  StatusCodes.Status400BadRequest;
            ViewBag.Message = $"There is a {statusCode} error here.";
            
        }
        BookViewModel? book = _context.Books.Find(id);
        if (book == null)
        {
             //return HttpNotFound();
            // return Error();
            statusCode =  StatusCodes.Status404NotFound;
            ViewBag.Message = $"There is a {statusCode} error here.";
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

    // public ActionResult Success()
    // {
    //     return View();
    // }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
