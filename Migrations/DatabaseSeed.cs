using bookish.Models;
using bookish.DataAccessLayer;


namespace bookish.Migrations;
public class DatabaseSeed
{
    private readonly BookishContext _context;

    public DatabaseSeed(BookishContext context)
    {
        _context = context;
    }


    public void Seed()
    {   
        if (!_context.Books.Any())
        {
            IEnumerable<BookViewModel> books = new List<BookViewModel>()
            {
                new BookViewModel()
                {
                    Id = 1,
                    BookId = 1234,
                    Title = "Entity Framework Core and How to Hate It!",
                    Author = "Robert",
                    Description = "The title says it all!"
                },
                new BookViewModel()
                {
                    Id = 2,
                    BookId = 5678,
                    Title = "Entity Framework Core and How to Hate It! Vol. 2",
                    Author = "Anum",
                    Description = "The title says it all!"
                },
            };

            _context.Books.AddRange(books);
            _context.SaveChanges();
        }


        
        if (!_context.Members.Any())
        {
            IEnumerable<Member> members = new List<Member>()
            {
                new Member()
                {
                    Id = 1,
                    Name = "Anum"
                    
                },
                new Member()
                {
                    Id = 2,
                    Name = "Robert"
                },
            };

            _context.Members.AddRange(members);
            _context.SaveChanges();
        }
        
        if (!_context.BorrowedBooks.Any())
        {
            IEnumerable<BorrowedBook> borrowedBooks = new List<BorrowedBook>()
            {
                new BorrowedBook()
                {
                    Id = 1,
                    MemberId = 1,
                    BookId = 2,
                    DueDate = new DateOnly(2024,09,01)
                    
                },
                new BorrowedBook()
                {
                    Id = 2,
                    MemberId = 1,
                    BookId = 4,
                    DueDate = new DateOnly(2024,09,04)
                },
                new BorrowedBook()
                {
                    Id = 3,
                    MemberId = 2,
                    BookId = 1,
                    DueDate = new DateOnly(2024,08,31)
                    
                },
                new BorrowedBook()
                {
                    Id = 4,
                    MemberId = 2,
                    BookId = 3,
                    DueDate = new DateOnly(2024,08,02)
                },
            };

            _context.BorrowedBooks.AddRange(borrowedBooks);
            _context.SaveChanges();
        }

    }
}
