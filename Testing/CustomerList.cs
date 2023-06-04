using System;
using System.Data;
using System.Collections.Generic;
using Dapper;
using LeadGeneration.Models;

namespace LeadGeneration;

public class CustomerList : ICustomerList
{
    private readonly IDbConnection _conn;
    public CustomerList (IDbConnection conn)
    {
        _conn = conn;
    }
    public IEnumerable<Customer> GetAllCustomers()
    {
        return  _conn.Query<Customer>("SELECT * FROM CUSTOMERS;");
    }
}
