using System.ComponentModel.DataAnnotations;

namespace IdentityMVC.Models;

public class ExternalLoginConfirmationModel
{
    [Required]
    public string Email { get; set; } = null!;

    [Required]
    public string Name { get; set; } = null!;
}
