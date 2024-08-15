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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            // This is the configuration used for connecting to the database
            optionsBuilder.UseNpgsql(@"Server=localhost;Port=5432;Database=bookish;User Id=bookish;Password=bookish;");
        }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<BookViewModel>().HasData(
    //         new BookViewModel
    //         {
    //             Id = 1,
    //             BookId = 1234,
    //             Title = "Entity Framework Core and How to Hate It!",
    //             Author = "Robert",
    //             Description = "The title says it all!"
    //         },
    //         new BookViewModel
    //         {
    //             Id = 2,
    //             BookId = 5678,
    //             Title = "Entity Framework Core and How to Hate It! Vol. 2",
    //             Author = "Anum",
    //             Description = "The title says it all!"
    //         },
    //     )
    // }
}
