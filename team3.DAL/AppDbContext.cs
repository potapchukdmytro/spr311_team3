using Microsoft.EntityFrameworkCore;

namespace team3.DAL

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options) { }
    }
}
