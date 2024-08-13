using bookish.Models;
using bookish.DataAccessLayer;


namespace bookish.Migrations;
public class BookTableSeed
{
    private readonly BookishContext _context;

    public BookTableSeed(BookishContext context)
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
    }
}
