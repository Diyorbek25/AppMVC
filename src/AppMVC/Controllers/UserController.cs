using AppMVC.Domain.Services;
using AppMVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AppMVC.Controllers;

public class UserController : Controller
{
    private readonly IUserService userService;

    public UserController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
        if(!string.IsNullOrEmpty(model.username) && string.IsNullOrEmpty(model.password))  
        {  
            return RedirectToAction("Login");
        }

        //Check the user name and password  
        //Here can be implemented checking logic from the database  
        var storageUser = userService.RetrieveUserByUserNameAndPassword()
            .FirstOrDefault(user => user.UserName == model.username && user.PasswordHash == model.password);
  
        if(storageUser != null){  
  
            //Create the identity for the user  
            var identity = new ClaimsIdentity(new[] {  
                new Claim(ClaimTypes.Name, storageUser.UserName),
                new Claim(ClaimTypes.Role, storageUser.UserRole.ToString()),
                new Claim(ClaimTypes.UserData, storageUser.Id.ToString())
            }, CookieAuthenticationDefaults.AuthenticationScheme);;  
  
            var principal = new ClaimsPrincipal(identity); 
  
            var login = HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme, principal); 
  
            return RedirectToAction("Index", "Home");  
        }
  
        return View();
    }


    public IActionResult Logout()
    {
        var login = HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);

        return RedirectToAction("Login");
    }
}
