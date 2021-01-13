using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
//Identifying the Database Schema

namespace Library.Models
{
  public class LibraryContext : IdentityDbContext<ApplicationUser>
  {
    public virtual DbSet<Author> Authors { get; set; } 
    public DbSet<Book> Books { get; set; }
    public DbSet<Collection> Collections { get; set; }
    public DbSet<AuthorBook> AuthorBook { get; set; }
    //public DbSet<AuthorBookPatron> AuthorBookPatron { get; set; }
    public LibraryContext(DbContextOptions options) : base(options) { } 
  }
}