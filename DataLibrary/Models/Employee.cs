namespace DataLibrary.Models;

public class Employee
{
    [Display(Name = "ID")]
    public int Id { get; set; }

    [Display(Name = "Employee ID")]
    public int EmployeeId { get; set; }

    [Display(Name = "First Name")]
    public string? FirstName { get; set; }

    [Display(Name = "Lastb Name")]
    public string? LastName { get; set; }

    [Display(Name = "Email Address")]
    public string? EmailAddress { get; set; }
}
