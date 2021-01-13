using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Models 
{
  public class Collection
  {
    public int CollectionId { get; set; }
    public int BookId { get; set; }
    public Book Book { get; set; }
  }
}
