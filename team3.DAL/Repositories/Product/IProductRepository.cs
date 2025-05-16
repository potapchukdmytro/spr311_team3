using team3.DAL.Entities;

namespace team3.DAL.Repositories.Product
{
    public interface IProductRepository
    {
        Task<bool> CreateAsync(ProductEntity entity);
        Task<bool> UpdateAsync(ProductEntity entity);
        Task<bool> DeleteAsync(ProductEntity entity);
        Task<ProductEntity?> GetByIdAsync(int id);
        IQueryable<ProductEntity?> GetAll();
        bool IsUnique(ProductEntity entity);
    }
}
