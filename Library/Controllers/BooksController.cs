using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Library.Controllers
{
  // [Authorize]
  public class BooksController : Controller
  {
    private readonly LibraryContext _db;
    // private readonly UserManager<ApplicationUser> _userManager;

    public BooksController(LibraryContext db)
    {
      // _userManager = userManager;
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Books.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.AuthorId = new SelectList(_db.Authors, "AuthorId", "AuthorName");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Book book, int AuthorId)
    {
      // var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      // var currentUser = await _userManager.FindByIdAsync(userId);
      // item.User = currentUser;
      _db.Books.Add(book);
      if (AuthorId != 0)
      {
        _db.AuthorBook.Add(new AuthorBook() { AuthorId = AuthorId, BookId = book.BookId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisBook = _db.Books
          .Include(book => book.JoinEntries)
          .ThenInclude(join => join.Author)
          .FirstOrDefault(book => book.BookId == id);
      return View(thisBook);
    }

    public ActionResult Edit(int id)
    {
      var thisBook = _db.Books.FirstOrDefault(book => book.BookId == id);
      ViewBag.AuthorId = new SelectList(_db.Authors, "AuthorId", "AuthorName"); // ViewBag only transfers data from controller to view
      return View(thisBook);
    }
    
    [HttpPost]
    public ActionResult Edit(Book book, int AuthorId)
    {
      if (AuthorId != 0)
      {
        _db.AuthorBook.Add(new AuthorBook() { AuthorId = AuthorId, BookId = book.BookId });
      }
      _db.Entry(book).State=EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddAuthor(int id)
    {
      var thisBook = _db.Books.FirstOrDefault(books => books.BookId == id);
      ViewBag.AuthorId = new SelectList(_db.Authors, "AuthorId", "AuthorName");
      return View(thisBook);
    }
    
    [HttpPost]
    public ActionResult AddAuthor(Book book, int AuthorId)
    {
      if(AuthorId != 0)
      {
        _db.AuthorBook.Add(new AuthorBook() { AuthorId = AuthorId, BookId = book.BookId});
      }
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    //   [HttpPost]
    // public ActionResult AddCourse(Student student, int CourseId)
    // {
    //   if (CourseId != 0)
    //   // Check if CourseId is valid
    //   {
    //     var returnedJoin = _db.CourseStudent.Any(join => join.StudentId == student.StudentId && join.CourseId == CourseId);
    //       Console.WriteLine(returnedJoin);
    //     // Check if "Any" of this relationship exists, returns a bool
    //     if (!returnedJoin) 
    //     {
    //     // if the returnedJoin for that relationship if false, then add the relationship
    //       _db.CourseStudent.Add(new CourseStudent() { CourseId = CourseId, StudentId = student.StudentId });
    //     }
    //   }
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }   

    public ActionResult Delete(int id)
    {
      var thisBook = _db.Books.FirstOrDefault(books => books.BookId == id);
      return View(thisBook);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisBook = _db.Books.FirstOrDefault(books => books.BookId == id);
      _db.Books.Remove(thisBook);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  
    [HttpPost]
    public ActionResult DeleteAuthor(int joinId)
    {
      var joinEntry = _db.AuthorBook.FirstOrDefault(entry => entry.AuthorBookId == joinId);
      _db.AuthorBook.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  }
}
