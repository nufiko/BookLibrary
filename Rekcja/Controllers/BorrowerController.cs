using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Rekcja.DAL;
using Rekcja.Models;
using Rekcja.ViewModels;

namespace Rekcja.Controllers
{
    public class BorrowerController : Controller
    {
        private LibraryContext db = new LibraryContext();

        // GET: Borrower
        public ActionResult Index(int ? id)
        {
            var viewModel = new BorrowerBookIndex();
            viewModel.Borrowers = db.Borrowers
                .Include(b => b.Books);
            if(id != null)
            {
                ViewBag.BorrowerID = id.Value;
                viewModel.Books = viewModel.Borrowers.Where(
                    b => b.ID == id.Value).Single().Books;
            }

            return View(viewModel);
            //return View(db.Borrowers.ToList());
        }

        // GET: Borrower/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Borrower borrower = db.Borrowers.Find(id);
            if (borrower == null)
            {
                return HttpNotFound();
            }
            return View(borrower);
        }

        // GET: Borrower/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Borrower/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Borrower borrower)
        {
            if (ModelState.IsValid)
            {
                db.Borrowers.Add(borrower);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(borrower);
        }

        // GET: Borrower/Edit/5
        public ActionResult Edit(int? id)
        {
            var viewModel = new BorrowerBookIndex();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Borrower borrower = db.Borrowers.Find(id);
            if (borrower == null)
            {
                return HttpNotFound();
            }
            viewModel.Borrowers = db.Borrowers.Where(b => b.ID == id);
            viewModel.Books = db.Books.Where(b => b.BorrowerID == id || b.BorrowerID == null);
            return View(viewModel);
        }

        // POST: Borrower/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Books")] Borrower borrower)
        {
            if (ModelState.IsValid)
            {
                db.Entry(borrower).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(borrower);
        }

        // GET: Borrower/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Borrower borrower = db.Borrowers.Find(id);
            if (borrower == null)
            {
                return HttpNotFound();
            }
            return View(borrower);
        }

        // POST: Borrower/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Borrower borrower = db.Borrowers.Find(id);
            IEnumerable<Book> books = db.Books.Where(book => book.BorrowerID == id);
            foreach(var book in books)
            {
                book.BorrowerID = null;
                book.BorrowDate = null;
            }
            db.Borrowers.Remove(borrower);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
