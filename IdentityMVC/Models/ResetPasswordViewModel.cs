using System.ComponentModel.DataAnnotations;

namespace IdentityMVC.Models;

public class ResetPasswordViewModel
{
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; } = null!;

    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long", MinimumLength = 4)]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; } = null!;

    [Required]
    [Display(Name = "Confirm Password")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Passwords must match")]
    public string ConfirmPassword { get; set; } = null!;

    public string Code { get; set; } = null!;
}
