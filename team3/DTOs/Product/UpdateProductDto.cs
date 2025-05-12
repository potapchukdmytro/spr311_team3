using System.ComponentModel.DataAnnotations;

namespace team3.DTOs.Product;

public class UpdateProductDto
{
    [Required]
    public int Id { get; set; } 

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [StringLength(500)]
    public string Description { get; set; }

    [Range(0.01, double.MaxValue)]
    public decimal Price { get; set; }

    [Range(0, int.MaxValue)]
    public int StockQuantity { get; set; }

    [Required]
    public int CategoryId { get; set; }
}