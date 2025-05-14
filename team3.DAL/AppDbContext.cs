using Microsoft.EntityFrameworkCore;
using team3.DAL.Entities;

namespace team3.DAL

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
    }
}
