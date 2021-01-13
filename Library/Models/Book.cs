using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
  public class Book
  {
    public Book()
    {
      this.JoinEntries = new HashSet<AuthorBook>();
    }
    
    //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
    public DateTime ReturnDate { get; set; }
    public int UserId { get; set; }
    public int BookId { get; set; }
    public string BookName { get; set; }
    public ICollection<AuthorBook> JoinEntries { get; }
    public virtual ApplicationUser User { get; set; }
  }
}  