namespace bookish.Models;

public class MemberViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int BookId { get; set; }
    public string BookTitle { get; set; } = "";
    public DateOnly? DueDate { get; set; } 
    
}
