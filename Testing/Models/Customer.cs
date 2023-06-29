using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LeadGeneration.Models;

public class Customer
{
    public Customer()
    { }

    public int CustomerID { get; set; }
    [StringLength(45, MinimumLength = 3)]
    [Required]
    public string FirstName { get; set; }

    [StringLength(45, MinimumLength = 3)]
    [Required]
    public string LastName { get; set; }
    public string MiddleInitial { get; set; }

    [StringLength(45)]
    [Required]
    public string EmailAddress { get; set; }
    
    [StringLength(25, MinimumLength = 10)]
    [Required]
    public string PhoneNumber  { get; set;}
    public string LeadReference { get; set; }
    public string BestTimeToCall { get; set; }

    [DataType(DataType.Date)]
    public System.DateTime DateOfBirth { get; set; }
    public bool Retired { get; set; }
    public int EmployeeCount { get; set; }

    [StringLength(30)]
    [Required]
    public IEnumerable<LeadReference> LeadReferences { get; set; }



}
