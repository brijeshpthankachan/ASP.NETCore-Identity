using Microsoft.AspNetCore.Identity;

namespace IdentityMVC.Models;

public class ApplicationUser : IdentityUser
{
    public string Name { get; set; } = null!;
}
