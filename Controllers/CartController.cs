using Microsoft.AspNetCore.Mvc;
using dotnet_store.Models;
using dotnet_store.Helpers;

namespace dotnet_store.Controllers
{
    public class CartController : Controller
    {
        private readonly DataContext _context;

        public CartController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetObject<List<CartItem>>("cart") ?? new List<CartItem>();
            return View(cart);
        }

        public IActionResult AddToCart(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if (product == null) return NotFound();

            var cart = HttpContext.Session.GetObject<List<CartItem>>("cart") ?? new List<CartItem>();

            var item = cart.FirstOrDefault(i => i.ProductId == id);
            if (item != null)
            {
                item.Quantity++;
            }
            else
            {
                cart.Add(new CartItem
                {
                    ProductId = product.ProductId,
                    ProductName = product.Name,
                    ImageUrl = product.ImageUrl,
                    Price = (decimal)product.Price,
                    Quantity = 1
                });
            }

            HttpContext.Session.SetObject("cart", cart);
            return RedirectToAction("Index");
        }
                
        public IActionResult Increase(int id)
        {
            var cart = HttpContext.Session.GetObject<List<CartItem>>("cart") ?? new List<CartItem>();
            var item = cart.FirstOrDefault(i => i.ProductId == id);
            if (item != null)
            {
                item.Quantity++;
                HttpContext.Session.SetObject("cart", cart);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Decrease(int id)
        {
            var cart = HttpContext.Session.GetObject<List<CartItem>>("cart") ?? new List<CartItem>();
            var item = cart.FirstOrDefault(i => i.ProductId == id);
            if (item != null)
            {
                if (item.Quantity > 1)
                    item.Quantity--;
                else
                    cart.Remove(item);

                HttpContext.Session.SetObject("cart", cart);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            var cart = HttpContext.Session.GetObject<List<CartItem>>("cart") ?? new List<CartItem>();
            var item = cart.FirstOrDefault(i => i.ProductId == id);
            if (item != null)
            {
                cart.Remove(item);
                HttpContext.Session.SetObject("cart", cart);
            }
            return RedirectToAction("Index");
        }
    }
}