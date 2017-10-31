using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rekcja.Models
{
    public class Book
    {
        public int ID { get; set; }

        [Required]
        public string Author { get; set; }
        [Required]
        public string Title { get; set; }

        [StringLength(13)]
        [Display(Name = "ISBN")]
        public string Isbn { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Borrow Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BorrowDate { get; set; }

        [Display(Name = "Borrower Name")]
        public int? BorrowerID { get; set; }

        public virtual Borrower Borrower { get; set; }
    }
}