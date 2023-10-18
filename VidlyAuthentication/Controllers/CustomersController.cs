using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyAuthentication.Models;
using VidlyAuthentication.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        //DISPOSABLE OBJECT
        private ApplicationDbContext _context;

        public CustomersController() 
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            //Deferred Execution - _context.Customers - Gets executed in the View
            //.ToList() - executes below
            //var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            { 
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            //create ViewModel when you want to encapsulate all required data models for the returned View(). In this case, Customer and MembershipType
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            //DATA-Validation
            if(!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
            {
                //NEW CUSTOMER
                //Data In Memory with below code line- marked as modified, added, deleted
                _context.Customers.Add(customer);
            }
            else 
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                //SECURE WAY TO UDPATE DB
                //You can also user AutoMapper in association with UdpateCustomerDto as parameter for this function, which exposes only properties that CAN be updated. Not all.
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
           
            //To persit the changes
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        //private IEnumerable<Customer> GetCustomers()
        //{ 
        //    return new List<Customer>
        //    {
        //        new Customer { Name="John Smith", Id=1},
        //        new Customer { Name="Marry Williams", Id=2}

        //    };
        //}

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}