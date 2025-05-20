using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnet_store.Models;

namespace dotnet_store.Controllers;

public class HomeController : Controller
{
    private readonly DataContext _context;

    public HomeController(DataContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var products = _context.Products
            .Include(p => p.Category)
            .ToList();

        return View(products);
    }

    [HttpGet]
    public IActionResult Contact()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Contact(ContactFormModel model)
    {
        if (model.Captcha != "12") 
        {
            ModelState.AddModelError("Captcha", "Doğrulama hatalı.");
        }

        if (ModelState.IsValid)
        {

            TempData["Success"] = "Mesajınız iletilmiştir, teşekkür ederiz!";
            return RedirectToAction("Contact");
        }

        return View(model);
    }
}