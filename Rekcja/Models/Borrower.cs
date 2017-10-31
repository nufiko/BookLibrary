using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rekcja.Models
{
    public class Borrower
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Borrower")]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}