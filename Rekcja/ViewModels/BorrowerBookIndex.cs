using Rekcja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rekcja.ViewModels
{
    public class BorrowerBookIndex
    {
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<Borrower> Borrowers { get; set; }
    }
}