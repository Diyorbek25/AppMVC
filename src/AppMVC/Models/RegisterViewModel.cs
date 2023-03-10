using System.ComponentModel.DataAnnotations;

namespace AppMVC.Models;

public class RegisterViewModel
{
    [MaxLength(20, ErrorMessage = "Username cannot exceed 20 characters")]
    public string UserName { get; set; }

    [MaxLength(30, ErrorMessage = "Password cannot exceed 30 characters")]
    public string Password { get; set; }

    [MaxLength(30, ErrorMessage = "Password cannot exceed 30 characters")]
    public string PasswordVerify { get; set; }
}
