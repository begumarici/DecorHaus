using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using dotnet_store.Models;

namespace dotnet_store.Controllers
{
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
                return RedirectToAction("Index", "Home");

            return View(product);
        }

        public IActionResult Search(string q)
        {
            var results = _context.Products
                .Include(p => p.Category)
                .Where(p => !string.IsNullOrEmpty(q) &&
                            (p.Name.ToLower().Contains(q.ToLower()) ||
                            p.Description.ToLower().Contains(q.ToLower())))
                .ToList();

            ViewBag.CategoryName = $"“{q}” için sonuçlar";
            return View("List", results);
        }

        public IActionResult List(int categoryId)
        {
            var category = _context.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
            if (category == null)
                return RedirectToAction("Index", "Home");

            var products = _context.Products
                .Include(p => p.Category)
                .Where(p => p.CategoryId == categoryId)
                .ToList();

            ViewBag.CategoryName = category.CategoryName;
            return View(products);
        }

        public IActionResult ListAll()
        {
            var products = _context.Products.Include(p => p.Category).ToList();
            ViewBag.CategoryName = "Tüm Ürünler";
            return View("List", products);
        }

        public IActionResult AdminList()
        {
            if (HttpContext.Session.GetString("role") != "admin")
                return RedirectToAction("Login", "Account");

            var products = _context.Products.Include(p => p.Category).ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            if (HttpContext.Session.GetString("role") != "admin")
                return RedirectToAction("Login", "Account");

            ViewBag.Categories = GetSelectListCategories();
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (HttpContext.Session.GetString("role") != "admin")
                return RedirectToAction("Login", "Account");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Products.Add(product);
                    int affected = _context.SaveChanges();

                    Console.WriteLine($"[DEBUG] Eklenen satır: {affected}");

                    return RedirectToAction("AdminList");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[HATA] SaveChanges başarısız: " + ex.Message);
                }
            }

            ViewBag.Categories = GetSelectListCategories();
            return View(product);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("role") != "admin")
                return RedirectToAction("Login", "Account");

            var product = _context.Products.Find(id);
            if (product == null) return NotFound();

            ViewBag.Categories = GetSelectListCategories();
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (HttpContext.Session.GetString("role") != "admin")
                return RedirectToAction("Login", "Account");

            if (ModelState.IsValid)
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return RedirectToAction("AdminList");
            }

            ViewBag.Categories = GetSelectListCategories();
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("role") != "admin")
                return RedirectToAction("Login", "Account");

            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }

            return RedirectToAction("AdminList");
        }

        // ✅ Yardımcı fonksiyon: SelectListItem listesi üretir
        private List<SelectListItem> GetSelectListCategories()
        {
            return _context.Categories
                .Select(c => new SelectListItem
                {
                    Value = c.CategoryId.ToString(),
                    Text = c.CategoryName
                }).ToList();
        }
    }
}