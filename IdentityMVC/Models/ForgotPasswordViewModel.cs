using System.ComponentModel.DataAnnotations;

namespace IdentityMVC.Models;

public class ForgotPasswordViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
}
