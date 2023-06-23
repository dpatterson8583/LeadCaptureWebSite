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
            repo.InsertCustomer(customerToInsert);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCustomer(Customer customer)
        {
            repo.DeleteCustomer(customer);
            return RedirectToAction("Index");
        }
    }
}