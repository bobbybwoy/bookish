namespace bookish.Models;

public class BorrowedBookViewModel
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public string? BookTitle { get; set; }
    public int MemberId { get; set; }
    public string? MemberName { get; set; }
    public DateOnly? DueDate { get; set; }
}
