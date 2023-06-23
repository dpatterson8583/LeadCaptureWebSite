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

    public Customer GetCustomer(int id)
    {
        return _conn.QuerySingle<Customer>("SELECT * FROM CUSTOMERS WHERE CUSTOMERID = @id;", new { id = id });
    }

    public void UpdateCustomer(Customer customer)
    {
        _conn.Execute("UPDATE CUSTOMERS SET FirstName = @firstname, LastName=@lastname, MiddleInitial=@middleinitial, " +
            "EmailAddress=@emailaddress, LeadReference=@leadreference,Retired=@retired, BestTimeToCall=@besttimetocall, " +
            "PhoneNumber=@phonenumber, DateOfBirth=@dateofbirth, EmployeeCount=@employeecount " +
            " WHERE CUSTOMERID = @id",
         new { firstname = customer.FirstName, lastname=customer.LastName, middleinitial=customer.MiddleInitial,
             emailaddress=customer.EmailAddress, leadreference=customer.LeadReference, retired=customer.Retired,
             besttimetocall=customer.BestTimeToCall, phonenumber=customer.PhoneNumber,dateofbirth=customer.DateOfBirth,
             employeecount=customer.EmployeeCount, id = customer.CustomerID });
    }

    public void InsertCustomer(Customer customerToInsert)
    {
        _conn.Execute("INSERT INTO customers (FIRSTNAME, MIDDLEINITIAL, LASTNAME, LEADREFERENCE, EMAILADDRESS," +
            "RETIRED,BESTTIMETOCALL,PHONENUMBER,DATEOFBIRTH,EMPLOYEECOUNT) " +
            "VALUES (@firstname, @middleinitial, @lastname, @leadreference, @emailaddress, @retired," +
            "@besttimetocall,@phonenumber,@dateofbirth,@employeecount);",
            new { firstname = customerToInsert.FirstName,middleinitial=customerToInsert.MiddleInitial, lastname = customerToInsert.LastName, 
                leadreference = customerToInsert.LeadReference, emailaddress=customerToInsert.EmailAddress, retired=customerToInsert.Retired, 
                besttimetocall=customerToInsert.BestTimeToCall, customerToInsert.PhoneNumber, customerToInsert.DateOfBirth, 
                customerToInsert.EmployeeCount  });
    }

    public IEnumerable<LeadReference> GetLeadReferences()
    {
        return _conn.Query<LeadReference>("SELECT * FROM reftypes;");
    }

    public Customer AssignLeadReference()
    {
        var categoryList = GetLeadReferences();
        var customer = new Customer();
        customer.LeadReferences = categoryList;
        return customer;
    }

    public void DeleteCustomer(Customer customer)
    {
        _conn.Execute("DELETE FROM Customers WHERE CustomerID = @id;", new { id = customer.CustomerID });
    }

 
}
