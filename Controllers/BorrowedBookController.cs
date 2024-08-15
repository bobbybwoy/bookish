using bookish;
using bookish.DataAccessLayer;
using bookish.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bookish.Controllers
{
    public class BorrowedBookController : Controller
    {
            private readonly ILogger<BorrowedBookController> _logger;
            private readonly BookishContext _context;

        public BorrowedBookController(ILogger<BorrowedBookController> logger, BookishContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: BorrowedBook
        public async Task<ActionResult> Index()
        {
            // Read through members
            // join
            var data = await (from bb in _context.BorrowedBooks
                        join mem in _context.Members
                        on bb.MemberId equals mem.Id
                        join bk in _context.Books
                        on bb.BookId equals bk.Id
                        //    where p.id == 1 and p.isRemote == 0
                        select new BorrowedBookViewModel
                        {
                            Id = bb.Id,
                            BookId = bb.BookId,
                            BookTitle = bk.Title,
                            MemberId = bb.MemberId,
                            MemberName = mem.Name,
                            DueDate = bb.DueDate,
                        }).OrderBy(d => d.DueDate).ToListAsync<BorrowedBookViewModel>();

            return View(data);
        }

    }
}
