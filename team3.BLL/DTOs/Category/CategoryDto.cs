namespace team3.DTOs.Category;

public class CategoryDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public int ProductCount { get; set; }
}