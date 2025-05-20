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

        public async Task<bool> CreateAsync(CategoryEntity entity)
        {
            await _context.Categories.AddAsync(entity);
            var result = await _context.SaveChangesAsync();
            return result != 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await FindByIdAsync(id);

            if (entity != null)
            {
                _context.Categories.Remove(entity);
                var result = await _context.SaveChangesAsync();
                return result != 0;
            }

            return false;
        }

        public async Task<CategoryEntity?> FindByIdAsync(int id)
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

        public async Task<bool> UpdateAsync(CategoryEntity entity)
        {
            if (await FindByNameAsync(entity.Name) == null)
            {
                _context.Categories.Update(entity);
                var result = await _context.SaveChangesAsync();
                return result != 0;
            }

            return false;
        }

        public bool IsUniqueName(string name)
        {
            return !_context.Categories.Any(c => c.Name == name);
        }
    }
}
