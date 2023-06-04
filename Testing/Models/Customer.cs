using Microsoft.VisualBasic;

namespace LeadGeneration.Models;

public class Customer
{
    public Customer()
    { }

    public int CustomerID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleInitial { get; set; }
    public string Email { get; set; }
    public string PhoneNumber  { get; set;}
    public string LeadReference { get; set; }
    public string BestTimeToCall { get; set; }
    public DateAndTime DOB { get; set; }
    public bool Retired { get; set; }
    public int EmployeeCount { get; set; }


}
