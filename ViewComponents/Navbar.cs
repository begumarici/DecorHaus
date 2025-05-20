using dotnet_store.Models;
using dotnet_store.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_store.ViewComponents
{
    public class Navbar : ViewComponent
    {
        private readonly DataContext _context;

        public Navbar(DataContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _context.Categories.ToList();

            var cart = HttpContext.Session.GetObject<List<CartItem>>("cart") ?? new List<CartItem>();


            ViewBag.CartCount = cart.Sum(i => i.Quantity);

            return View(categories); 
        }
    }
}