using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnet_store.Models;

namespace dotnet_store.Controllers;

public class ProductController : Controller
{
    private readonly DataContext _context;

    public ProductController(DataContext context)
    {
        _context = context;
    }

    public IActionResult Details(int id)
    {
        var product = _context.Products
            .Include(p => p.Category)
            .FirstOrDefault(p => p.ProductId == id);

        if (product == null)
        {
            return RedirectToAction("Index", "Home");
        }

        return View(product);
    }

    // Belirli kategoriye ait ürünleri listele
    public IActionResult List(int categoryId)
    {
        var category = _context.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
        if (category == null)
        {
            return RedirectToAction("Index", "Home");
        }

        var products = _context.Products
            .Include(p => p.Category)
            .Where(p => p.CategoryId == categoryId)
            .ToList();

        ViewBag.CategoryName = category.CategoryName;
        return View(products);
    }

    // Tüm ürünleri listele (ÜRÜNLER'e tıklayınca buraya gelsin)
    public IActionResult ListAll()
    {
        var products = _context.Products
            .Include(p => p.Category)
            .ToList();

        ViewBag.CategoryName = "Tüm Ürünler";
        return View("List", products); // Aynı List.cshtml görünümünü kullanır
    }
}