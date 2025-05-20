using dotnet_store.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_store.ViewComponents;

public class Slider : ViewComponent
{
    private readonly DataContext _context;

    public Slider(DataContext context)
    {
        _context = context;
    }

    public IViewComponentResult Invoke()
    {
        var sliders = _context.Sliders
            .Where(s => s.IsActive)
            .OrderBy(s => s.DisplayIndex)
            .ToList();

        return View(sliders);
    }
}