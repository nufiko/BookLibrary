using Rekcja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rekcja.DAL
{
    public class TestData : System.Data.Entity.DropCreateDatabaseIfModelChanges<LibraryContext>
    {
        protected override void Seed(LibraryContext context)
        {
            var borrowers = new List<Borrower>
            {
                new Borrower{Name = "Maciek"},
                new Borrower{Name = "Kasia"},
                new Borrower{Name = "Chudy"}
            };

            borrowers.ForEach(b => context.Borrowers.Add(b));

            context.SaveChanges();

            var books = new List<Book>
            {
                new Book{Title = "Robinson Crusoe", Author = "Daniel Defoe"},
                new Book{Title = "Miecz Przeznaczenia", Author = "Andrzej Sapkowski", BorrowerID = 1, BorrowDate = DateTime.Parse("2017-01-20")},
                new Book{Title = "Władca Pierścieni - Dwie Wieże", Author = "J.R.R Tolkien", BorrowerID = 3, BorrowDate = DateTime.Parse("2017-04-16")},
                new Book{Title = "Znaczy Kapitan", Author = "Karol Olgierd Borhardt"},
                new Book{Title = "Straż Straż", Author = "Terry Pratchett"}
            };

            books.ForEach(b => context.Books.Add(b));
            context.SaveChanges();
        }
    }
}