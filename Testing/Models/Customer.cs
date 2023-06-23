using Microsoft.VisualBasic;
using System.Collections.Generic;

namespace LeadGeneration.Models;

public class Customer
{
    public Customer()
    { }

    public int CustomerID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleInitial { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber  { get; set;}
    public string LeadReference { get; set; }
    public string BestTimeToCall { get; set; }
    public System.DateTime DateOfBirth { get; set; }
    public bool Retired { get; set; }
    public int EmployeeCount { get; set; }
    public IEnumerable<LeadReference> LeadReferences { get; set; }



}
