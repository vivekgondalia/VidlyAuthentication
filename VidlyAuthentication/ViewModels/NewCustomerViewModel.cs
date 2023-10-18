using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyAuthentication.Models;

namespace VidlyAuthentication.ViewModels
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        //ABOVE will give us list of membership types without the functinalities of a list() such as removing, indexing, accessing the list
        //public List<MembershipType> MembershipTypes { get; set; }

        public Customer Customer { get; set; }

    }
}