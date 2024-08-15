namespace bookish.Models;

public class BorrowedBook
{
    public int Id { get; set; }
    public int MemberId { get; set; }
    public int BookId { get; set; }
    public DateOnly DueDate { get; set; }
}