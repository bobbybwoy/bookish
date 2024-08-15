using Microsoft.AspNetCore.Mvc;
using bookish.Models;
using bookish.DataAccessLayer;

namespace bookish.Controllers;

public class MemberController : Controller
{
    private readonly ILogger<MemberController> _logger;
    private readonly BookishContext _context;

    public MemberController(ILogger<MemberController> logger, BookishContext context)
    {
        _logger = logger;
        _context = context;
    }
    // GET: MemberController : prints a list of members
    public ActionResult Index()
    {
        return View();
    }

}

