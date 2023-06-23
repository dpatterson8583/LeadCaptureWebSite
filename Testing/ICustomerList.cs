using System;
using System.Collections.Generic;
using LeadGeneration.Models;

namespace LeadGeneration
{
    public interface ICustomerList
    {
        public IEnumerable<Customer> GetAllCustomers();
        public Customer GetCustomer(int id);
        public void UpdateCustomer(Customer customer);
        public void InsertCustomer(Customer customerToInsert);
        public IEnumerable<LeadReference> GetLeadReferences();
        public Customer AssignLeadReference();
        public void DeleteCustomer(Customer customer);
    }
}
