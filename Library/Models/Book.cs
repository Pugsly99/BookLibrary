using System.Collections.Generic;

namespace Library.Models
{
  public class Book
  {
    public Book()
    {
      this.JoinEntries = new HashSet<AuthorBook>();
    }

    public int BookId { get; set; }
    public string BookName { get; set; }

    public ICollection<AuthorBook> JoinEntries { get; }
  }
}  