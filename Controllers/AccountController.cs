using dotnet_store.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_store.Controllers;

public class AccountController : Controller
{
    private readonly DataContext _context;

    public AccountController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    public IActionResult Login(User user)
    {
        var existingUser = _context.Users
            .FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);

        if (existingUser != null)
        {
            HttpContext.Session.SetString("user", existingUser.Username);
            HttpContext.Session.SetString("role", existingUser.Role ?? "user");

            return RedirectToAction("Index", "Home");
        }

        ViewBag.Error = "Kullanıcı adı veya şifre yanlış.";
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear(); 
        return RedirectToAction("Index", "Home");
    }
}