namespace Library.Models
{
  public class AuthorBook
  {
    public int AuthorBookId { get; set; }
    public int UserId { get; set; }
    public AuthorBook AuthorBook { get; set; }
  }
}