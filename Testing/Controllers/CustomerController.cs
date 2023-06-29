using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LeadGeneration.Models;

namespace LeadGeneration.Controllers
{
    public class CustomerController : Controller
    {

        private readonly ICustomerList repo;

        public CustomerController(ICustomerList repo)
        {
            this.repo = repo;
        }

        public IActionResult CustomerAdmin()
        {
            return View();
        }

        public IActionResult Index()
        {
            var customers = repo.GetAllCustomers();
            return View(customers);
        }

        public async Task<IActionResult>Search(string searchString, string searchTarget)
        {
            if (repo.GetAllCustomers() == null)
            {
                return Problem("Entity set 'Customers'  is null.");
            }

            var customers = from c in repo.GetAllCustomers()
                            select c;

            if (!String.IsNullOrEmpty(searchString) && !String.IsNullOrEmpty(searchTarget))
            {
                if (searchTarget == "LastName")
                {
                    customers = customers.Where(c => c.LastName.ToLower()!.Contains(searchString.ToLower()));
                }
                else if (searchTarget == "Email")
                {
                    customers = customers.Where(c => c.EmailAddress.ToLower()!.Contains(searchString.ToLower()));
                }
                else if (searchTarget == "LeadReference")
                {
                    customers = customers.Where(c => c.LeadReference.ToLower()!.Contains(searchString.ToLower()));
                }

            }

            return View(customers);

            //var customers = repo.GetAllCustomers();
            // return View(customers);
        }

        //Simple, single field search.  Attached the "X" to take it out of play.
        public async Task<IActionResult> SearchX(string searchString)
         {
                if (repo.GetAllCustomers()  == null)
                {
                    return Problem("Entity set Customers'  is null.");
                }

                var customers = from c in repo.GetAllCustomers()
                             select c;

                if (!String.IsNullOrEmpty(searchString))
                {
                    customers = customers.Where(c => c.LastName.ToLower()!.Contains(searchString.ToLower()));
                }

                return View(customers);
         
            //var customers = repo.GetAllCustomers();
           // return View(customers);
        }
        
        public IActionResult ViewCustomer(int id)
        {
            var customer = repo.GetCustomer(id);
            return View(customer);
        }

        public IActionResult UpdateCustomer(int id)
        {
            Customer cust = repo.GetCustomer(id);
            if (cust == null)
            {
                return View("CustomerNotFound");
            }
            //cust.LeadReferences = repo.GetLeadReferences();
            return View(cust);
        }

        public IActionResult UpdateCustomerToDatabase(Customer customer)
        {
            customer.Retired = (customer.Retired.ToString()=="True") ? true : false;

            repo.UpdateCustomer(customer);

            return RedirectToAction("ViewCustomer", new { id = customer.CustomerID });
        }

        public IActionResult InsertCustomer()
        {
            var cust = repo.AssignLeadReference();
            return View(cust);
        }

        public IActionResult InsertCustomerToDatabase(Customer customerToInsert)
        {
            if(customerToInsert.FirstName != null && customerToInsert.LastName!=null && customerToInsert.PhoneNumber!=null)
            {
                repo.InsertCustomer(customerToInsert);
            }
            
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCustomer(Customer customer)
        {
            repo.DeleteCustomer(customer);
            return RedirectToAction("Index");
        }
    }
}