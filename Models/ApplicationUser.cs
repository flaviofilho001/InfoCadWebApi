using Microsoft.AspNetCore.Identity;

namespace InfoCad.Models;

public class ApplicationUser : IdentityUser
{
    public string? Cpf {  get; set; }
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
}
