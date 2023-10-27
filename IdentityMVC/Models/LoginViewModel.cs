using System.ComponentModel.DataAnnotations;

namespace IdentityMVC.Models;

public class LoginViewModel
{
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; } = null!;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Required]
    [Display(Name = "Remember me?")]
    public bool RememberMe { get; set; }
}
