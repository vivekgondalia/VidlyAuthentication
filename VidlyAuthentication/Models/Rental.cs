using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using VidlyAuthentication.Models;


namespace VidlyAuthentication.Models
{
    public class Rental
    {
        public int Id { get; set; }

        [Display(Name = "Checkout Date")]
        public DateTime DateRented { get; set; }
        
        [Display(Name = "Return Date")]
        public DateTime? DateReturned { get; set; }

        [Required]
        public Customer Customer { get; set; }

        [Required]
        public Movie Movie { get; set; }
    }
}