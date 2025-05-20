using AutoMapper;
using Microsoft.EntityFrameworkCore;
using team3.DAL.Entities;
using team3.DAL.Repositories.Product;
using team3.DTOs.Category;
using team3.DTOs.Product;

namespace team3.BLL.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<ServiceResponse> CreateAsync(CreateProductDto dto)
        {
            var entity = _mapper.Map<ProductEntity>(dto);
            if (!_productRepository.IsUniqueName(entity))
            {
                return ServiceResponse.Error($"Продукт з іменем {dto.Name}");
            }

            var result = await _productRepository.CreateAsync(entity);

            if (result)
            {
                return ServiceResponse.Success("Продукт успішно створено");
            }
            return ServiceResponse.Error("Продукт не створено");
        }

        public async Task<ServiceResponse> DeleteAsync(int id)
        {
            var entity = await _productRepository.GetByIdAsync(id);
            
            if (entity == null)
            {
                return ServiceResponse.Error("Продукт не знайдено");
            }

            var result =  await _productRepository.DeleteAsync(entity);
            if (result)
            {
                return ServiceResponse.Success("Продукт успішно видалено");
            }
            return ServiceResponse.Error("Продукт не видалено");
        }

        public async Task<ServiceResponse> GetAllAsync()
        {
            var entities = await _productRepository.GetAll().ToListAsync();

            var dtos = _mapper.Map<List<ProductDto>>(entities);

            return ServiceResponse.Success("Продукти отримано", dtos);
        }

        public async Task<ServiceResponse> GetByIdAsync(int id)
        {
            var entity = await _productRepository.GetByIdAsync(id);
            if (entity != null)
            {
                var dto = _mapper.Map<ProductDto>(entity);
                return ServiceResponse.Success("Продукт отримано", dto);
            }
            return ServiceResponse.Error("Продукт не знайдено");

        }

        public async Task<ServiceResponse> UpdateAsync(UpdateProductDto dto)
        {
            var entity = _mapper.Map<ProductEntity>(dto);
            if (!_productRepository.IsUniqueName(entity))
            {
                return ServiceResponse.Error("Ім'я продукта не унікальне");
            }
            var result = await _productRepository.UpdateAsync(entity);
            if (result)
            {
                return ServiceResponse.Success("Продукт оновлено успішно");
            }
            return ServiceResponse.Error("Продукт не оновлено");
        }
    }
}
