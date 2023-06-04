using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LeadGeneration.Controllers
{
    public class CustomerController : Controller
    {

        private readonly ICustomerList repo;

        public CustomerController(ICustomerList repo)
        {
            this.repo = repo;
        }


        public IActionResult Index()
        {
            var customers = repo.GetAllCustomers();
            return View(customers);
        }
    }
}