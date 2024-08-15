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

    public async Task<IActionResult> Details(int? id)
    {
        //To do: need a view for Details
        var data = await (from mem in _context.Members
                        join bb in _context.BorrowedBooks
                        on mem.Id equals bb.MemberId
                        join bk in _context.Books
                        on bb.BookId equals bk.Id
                        where mem.Id == id 
                        select new MemberViewModel
                        {
                            Id = mem.Id,
                            Name = mem.Name,
                            BookId = bb.BookId,
                            BookTitle = bk.Title,
                            DueDate = bb.DueDate,
                        }).OrderBy(d => d.DueDate).ToListAsync<MemberViewModel>();
        return View();
    }

}

