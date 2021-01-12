// using Microsoft.AspNetCore.Mvc;
// using Library.Models;
// using System.Collections.Generic;
// using System.Linq;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Mvc.Rendering;

// namespace Library.Controllers
// {
//   // [Authorize]
//   public class CopiesController : Controller
//   {
//     private readonly LibraryContext _db;
//     // private readonly UserManager<ApplicationUser> _userManager;

//     public CopiesController(LibraryContext db)
//     {
//       // _userManager = userManager;
//       _db = db;
//     }

//     public ActionResult Index()
//     {
//       return View(_db.Copies.ToList());
//     }

//     public ActionResult Create()
//     {
//       ViewBag.BookId = new SelectList(_db.Books, "BookId", "BookName");
//       return View();
//     }

//     [HttpPost]
//     public ActionResult Create(Copy copy, int BookId)
//     {
//       // var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
//       // var currentUser = await _userManager.FindByIdAsync(userId);
//       // item.User = currentUser;
//       _db.Copies.Add(copy);
//       if (BookId != 0)
//       {
//         _db.BookCopy.Add(new BookCopy() { BookId = BookId, CopyId = copy.CopyId });
//       }
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//     }

//     public ActionResult Details(int id)
//     {
//       var thisCopy = _db.Copies
//           .Include(child => child.JoinEntries)
//           .ThenInclude(join => join.Book)
//           .FirstOrDefault(child => copy.CopyId == id);
//       return View(thisCopy);
//     }

//     public ActionResult Edit(int id)
//     {
//       var thisCopy = _db.Copies.FirstOrDefault(copy => copy.CopyId == id);
//       ViewBag.BookId = new SelectList(_db.Books, "BookId", "BookName"); // ViewBag only transfers data from controller to view
//       return View(thisCopy);
//     }
    
//     [HttpPost]
//     public ActionResult Edit(Copy copy, int BookId)
//     {
//       if (BookId != 0)
//       {
//         _db.BookCopy.Add(new BookCopy() { BookId = BookId, CopyId = copy.CopyId });
//       }
//       _db.Entry(copy).State=EntityState.Modified;
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//     }

//     public ActionResult AddBook(int id)
//     {
//       var thisCopy = _db.Copies.FirstOrDefault(copy => copy.CopyId == id);
//       ViewBag.BookId = new SelectList(_db.Books, "BookId", "BookName");
//       return View(thisCopy);
//     }
    
//     [HttpPost]
//     public ActionResult AddBook(Copy copy, int BookId)
//     {
//       if(BookId != 0)
//       {
//         _db.BookCopy.Add(new BookCopy() { BookId = BookId, CopyId = copy.CopyId});
//       }
//         _db.SaveChanges();
//         return RedirectToAction("Index");
//     }

//     //   [HttpPost]
//     // public ActionResult AddCourse(Student student, int CourseId)
//     // {
//     //   if (CourseId != 0)
//     //   // Check if CourseId is valid
//     //   {
//     //     var returnedJoin = _db.CourseStudent.Any(join => join.StudentId == student.StudentId && join.CourseId == CourseId);
//     //       Console.WriteLine(returnedJoin);
//     //     // Check if "Any" of this relationship exists, returns a bool
//     //     if (!returnedJoin) 
//     //     {
//     //     // if the returnedJoin for that relationship if false, then add the relationship
//     //       _db.CourseStudent.Add(new CourseStudent() { CourseId = CourseId, StudentId = student.StudentId });
//     //     }
//     //   }
//     //   _db.SaveChanges();
//     //   return RedirectToAction("Index");
//     // }   

//     public ActionResult Delete(int id)
//     {
//       var thisCopy = _db.Copies.FirstOrDefault(copy => copy.CopyId == id);
//       return View(thisCopy);
//     }

//     [HttpPost, ActionName("Delete")]
//     public ActionResult DeleteConfirmed(int id)
//     {
//       var thisCopy = _db.Copies.FirstOrDefault(copy => copy.CopyId == id);
//       _db.Copies.Remove(thisCopy);
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//     }
  
//     [HttpPost]
//     public ActionResult DeleteBook(int joinId)
//     {
//       var joinEntry = _db.BookCopy.FirstOrDefault(entry => entry.BookCopyId == joinId);
//       _db.BookCopy.Remove(joinEntry);
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//     }
//   }
// }
