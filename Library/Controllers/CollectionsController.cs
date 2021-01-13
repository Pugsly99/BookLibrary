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
  public class CollectionsController : Controller
  {
    private readonly LibraryContext _db;
    public CollectionsController(LibraryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View();
    }

    public ActionResult Create(int id)
    {
      var thisBook = _db.Books.FirstOrDefault(book => book.BookId == id);
      return View(thisBook);
    }
    
    [HttpPost]
    public ActionResult Create(Collection collection)
    {
      _db.Collections.Add(collection);
      _db.SaveChanges();
      return RedirectToAction("Index","Books");
    }

    public ActionResult Delete(int id)
    {
      var thisCopy = _db.Collections.FirstOrDefault(author => author.CollectionId == id);
      return View(thisCopy);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisCopy = _db.Collections.FirstOrDefault(author => author.CollectionId == id);
      _db.Collections.Remove(thisCopy);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  }
}