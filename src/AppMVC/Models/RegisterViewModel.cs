using System.ComponentModel.DataAnnotations;

namespace AppMVC.Models;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Username is required")]
    [MaxLength(20, ErrorMessage = "Username cannot exceed 20 characters")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [MaxLength(30, ErrorMessage = "Password cannot exceed 30 characters")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [MaxLength(30, ErrorMessage = "Password cannot exceed 30 characters")]
    public string PasswordVerify { get; set; }
}
