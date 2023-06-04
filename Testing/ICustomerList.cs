using System;
using System.Collections.Generic;
using LeadGeneration.Models;

namespace LeadGeneration
{
    public interface ICustomerList
    {
        public IEnumerable<Customer> GetAllCustomers();
    }
}
