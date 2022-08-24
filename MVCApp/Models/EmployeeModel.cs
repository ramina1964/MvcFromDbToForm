using System.ComponentModel.DataAnnotations;

namespace MVCApp.Models;

public class EmployeeModel
{
    [Display(Name = "Employee Id")]
    [Required(ErrorMessage = "Employee ID is required.")]
    [Range(minimum: 100000, maximum: 999999, ErrorMessage = "Invalid Employee Id.")]
    public int Id { get; set; }

    [Display(Name = "First Name")]
    [Required(ErrorMessage = "First name is required.")]
    public string? FirstName { get; set; }

    [Display(Name = "Last Name")]
    [Required(ErrorMessage = "Last name is required.")]
    public string? LastName { get; set; }

    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email Address")]
    [Required(ErrorMessage = "Email Address is required,")]
    public string? EmailAddress { get; set; }

    [Display(Name = "Confirm Email")]
    [Compare("EmailAddress", ErrorMessage = "The Email Address and confirm email must match.")]
    public string? ConfirmEmail { get; set; }

    [Display(Name = "Password")]
    [Required(ErrorMessage = "Password is required.")]
    [DataType(DataType.Password)]
    [StringLength(100, MinimumLength = 10, ErrorMessage = "Password length must be at least 10 character long.")]
    public string? Password { get; set; }

    [Display(Name = "Confirm Password")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Password and confirm password must match.")]
    public string? ConfirmPassword { get; set; }
}
