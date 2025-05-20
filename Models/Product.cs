namespace dotnet_store.Models;

using System.ComponentModel.DataAnnotations;

public class Product
{
    public int ProductId { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Description { get; set; }

    [Required]
    [Range(1, double.MaxValue, ErrorMessage = "Fiyat 0'dan büyük olmalıdır.")]
    public decimal Price { get; set; }

    [Required]
    public string? ImageUrl { get; set; }

    [Required]
    public int CategoryId { get; set; }

    public Category? Category { get; set; }
}