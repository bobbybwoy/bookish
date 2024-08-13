using Microsoft.EntityFrameworkCore;
using bookish.Models;
// using System;

// using System.Linq;
// using System.Web;
// using System.Data.Entity;



// namespace bookish;
namespace bookish.DataAccessLayer;

public class BookishContext : DbContext
{
    public DbSet<BookViewModel> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            // This is the configuration used for connecting to the database
            optionsBuilder.UseNpgsql(@"Server=localhost;Port=5432;Database=bookish;User Id=bookish;Password=bookish;");
        }
}
