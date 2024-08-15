using Microsoft.EntityFrameworkCore;
using bookish.Models;


// namespace bookish;
namespace bookish.DataAccessLayer;

public class BookishContext : DbContext
{
    public BookishContext (DbContextOptions<BookishContext> options) : base(options)
    {
    }
    public DbSet<BookViewModel> Books { get; set; }
    public DbSet<MemberViewModel> Members { get; set; }
    public DbSet<BorrowedBook> BorrowedBooks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            // This is the configuration used for connecting to the database
            optionsBuilder.UseNpgsql(@"Server=localhost;Port=5432;Database=bookish;User Id=bookish;Password=bookish;");
        }
}
