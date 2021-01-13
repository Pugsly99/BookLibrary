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
using System.Globalization;
using System;

namespace Library.Controllers
{
  [Authorize]
  public class CheckoutsController : Controller
  {
    private readonly LibraryContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    public CheckoutsController(UserManager<ApplicationUser> userManager,LibraryContext db)
    {
      _userManager = userManager;
      _db = db;
    }
    public ActionResult Index()
    {
      return View();
    }
    public ActionResult Confirm(int id)
    {
      var thisBook = _db.Books.FirstOrDefault(book => book.BookId == id);
      return View(thisBook);
    }

    [HttpPost]
    public async Task<ActionResult> Confirm(Book book)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      book.User = userId;
      DateTime today = DateTime.Now;
      DateTime returnDate = today.AddDays(7);
      book.ReturnDate = returnDate;
      _db.Entry(book).State=EntityState.Modified;
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

    public ActionResult Return(int id)
    {
      var thisBook = _db.Books.FirstOrDefault(book => book.BookId == id);
      return View(thisBook);
    }
    
    [HttpPost]
    public ActionResult Return(Book book)
    {
      book.User = null;
      _db.Entry(book).State=EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
