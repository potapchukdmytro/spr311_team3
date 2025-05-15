using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using team3.DAL.Entities;

namespace team3.DAL.Repositories.Category
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(CategoryEntity entity)
        {
            await _context.Categories.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await FindByIdAsync(id);
            if (entity != null)
            {
                _context.Categories.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<CategoryEntity?> FindByIdAsync(string id)
        {
            return await _context.Categories.FirstOrDefaultAsync(e => e.Id.Equals(id));
        }

        public async Task<CategoryEntity?> FindByNameAsync(string name)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Name == name);
        }

        public IQueryable<CategoryEntity> GetAll()
        {
            return _context.Categories;
        }

        public async Task UpdateAsync(CategoryEntity entity)
        {
            _context.Categories.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
