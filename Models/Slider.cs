namespace dotnet_store.Models;

public class Slider
{
    public int SliderId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string ImageUrl { get; set; } = null!;
    public int DisplayIndex { get; set; }
    public bool IsActive { get; set; }
}