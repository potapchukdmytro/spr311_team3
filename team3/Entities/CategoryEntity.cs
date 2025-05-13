using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace team3.Entities;

public class CategoryEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [StringLength(500)]
    public string Description { get; set; }

    public virtual ICollection<ProductEntity> Products { get; set; }
}