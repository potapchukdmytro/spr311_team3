using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using team3.DTOs.Category;

namespace team3.BLL.Services.Category
{
    public interface ICategoryService
    {
        Task<ServiceResponse> CreateAsync(CreateCategoryDto dto);
        Task<ServiceResponse> UpdateAsync(UpdateCategoryDto dto);
        Task<ServiceResponse> DeleteAsync(int id);
        Task<ServiceResponse> GetByIdAsync(int id);
        Task<ServiceResponse> GetByNameAsync(string name);
        Task<ServiceResponse> GetAllAsync();
    }
}
