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
        Task CreateAsync(CategoryEntity entity);
        Task UpdateAsync(CategoryEntity entity);
        Task DeleteAsync(string id);
        Task<CategoryEntity?> FindByIdAsync(string id);
        Task<CategoryEntity?> FindByNameAsync(string name);
        IQueryable<CategoryEntity> GetAll();
    }
}
