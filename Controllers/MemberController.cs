using Microsoft.AspNetCore.Mvc;
using bookish.Models;
using bookish.DataAccessLayer;
using Microsoft.EntityFrameworkCore;

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
    public async Task<IActionResult> Index()
    {
        return View(await _context.Members.OrderBy(member => member.Id).ToListAsync());
    }

}

