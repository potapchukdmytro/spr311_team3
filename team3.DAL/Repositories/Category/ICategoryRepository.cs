using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using team3.DAL.Entities;

namespace team3.DAL.Repositories.Category
{
    public interface ICategoryRepository
    {
        Task<bool> CreateAsync(CategoryEntity entity);
        Task<bool> UpdateAsync(CategoryEntity entity);
        Task<bool> DeleteAsync(int id);
        Task<CategoryEntity?> FindByIdAsync(int id);
        Task<CategoryEntity?> FindByNameAsync(string name);
        IQueryable<CategoryEntity> GetAll();
        public bool IsUniqueName(string name);
    }
}
