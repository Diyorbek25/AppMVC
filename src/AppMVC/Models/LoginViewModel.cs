using System.ComponentModel.DataAnnotations;

namespace AppMVC.Models;

public class LoginViewModel
{
    [Required(ErrorMessage = "Username is required")]
    [MaxLength(20, ErrorMessage = "Username cannot exceed 20 characters")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [MaxLength(30, ErrorMessage = "Password cannot exceed 30 characters")]
    public string Password { get; set; }
}