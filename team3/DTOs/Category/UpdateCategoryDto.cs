using System.ComponentModel.DataAnnotations;

namespace team3.DTOs.Category;

public class UpdateCategoryDto
{
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [StringLength(500)]
    public string Description { get; set; }
}