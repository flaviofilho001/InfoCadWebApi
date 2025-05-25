using System.ComponentModel.DataAnnotations;

namespace InfoCad.DTOs;

public class RegisterModel
{
    [Required(ErrorMessage = "User Name is required")]
    public string? Username { get; set; }

    [EmailAddress]
    [Required(ErrorMessage = "Email is required")]
    public string? Email { get; set; }
    [Required(ErrorMessage = "CPF is required")]
    public string? Cpf { get; set; }
    [Required(ErrorMessage = "Numero is required")]
    public string? PhoneNumber { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; set; }
}
