using team3.DTOs.Product;

namespace team3.BLL.Services.Product
{
    public interface IProductService
    {
        Task<ServiceResponse> CreateAsync(CreateProductDto dto);
        Task<ServiceResponse> UpdateAsync(UpdateProductDto dto);
        Task<ServiceResponse> DeleteAsync(int id);
        Task<ServiceResponse> GetByIdAsync(int id);
        Task<ServiceResponse> GetAllAsync();
    }
}
