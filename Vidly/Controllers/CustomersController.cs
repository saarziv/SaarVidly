using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(cm => cm.MembershipType).SingleOrDefault(cid => cid.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(customer);
            }
        }
        public ActionResult New()
        {
            var ViewModel = new CustomerFormViewModel()
            {
                Customer = new Customer(),
                MembershipType = _context.MembershipTypes.ToList()
            };
            
            return View("CustomerForm",ViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (!ModelState.IsValid )
            {
                CustomerFormViewModel ViewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipType = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", ViewModel);
            }
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDB = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDB.Name = customer.Name;
                customerInDB.IsSubscribedtoNewsLetter = customer.IsSubscribedtoNewsLetter;
                customerInDB.MembershipTypeId = customer.MembershipTypeId;
                customerInDB.BirthDate = customer.BirthDate;

            }
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);

            }
            return RedirectToAction("Index", "Customers");
        }
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(cid => cid.Id == id);
            if (customer == null)
                return HttpNotFound();
            CustomerFormViewModel ViewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipType = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm",ViewModel);
        }
     
        /*SingleOrDefault returns to customer a single value from the list.
            the value that will be returned depends 
            on the value that the delegate passed in 
            the method(delegate = a method that is passed as an argument) will return

            in this delegate we use lamda expression => , cid in this case is the value that is returned
            from the SingleOrDefault method, according to the bool expression after the lamda expression

            if its false , the SingleOrDefault method wouldnt find a value , 
            and therefore will return default value which is null.
            */
    }
}