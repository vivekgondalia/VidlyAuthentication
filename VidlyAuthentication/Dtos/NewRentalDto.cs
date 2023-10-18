using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidlyAuthentication.Dtos
{
    public class NewRentalDto
    {
        //public byte Id { get; set; }
        //public CustomerDto CustomerDto { get; set; }
        //public MovieDto MovieDto { get; set; }

        public int CustomerId { get; set; }
        public List<int> MovieIds { get; set; }
    }
}