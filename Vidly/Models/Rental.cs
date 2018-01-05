using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class Rental
    {
        
        public int Id { get; set; }

        
        [Display(Name = "Date Rented")]
        public DateTime DateRented { get; set; }

        
        [Display(Name = "Date Returned")]
        public DateTime? DateReturned { get; set; }

        [Required]
        public Movie Movie { get; set; }

        [Required]
        public Customer Customer { get; set; }
        
    }
}