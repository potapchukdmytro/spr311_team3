using AutoMapper;
using Microsoft.EntityFrameworkCore;
using team3.DAL.Entities;
using team3.DAL.Repositories.Category;
using team3.DTOs.Category;

namespace team3.BLL.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse> CreateAsync(CreateCategoryDto dto)
        {
            if (!_categoryRepository.IsUniqueName(dto.Name))
            {
                return ServiceResponse.Error($"Категорія з іменем {dto.Name} вже існує");
            }

            var entity = _mapper.Map<CategoryEntity>(dto);

            bool result = await _categoryRepository.CreateAsync(entity);

            if (result)
            {
                return ServiceResponse.Success($"Категорію {entity.Name} успішно доданг");
            }

            return ServiceResponse.Error($"Не вдалося створити категорію");
        }

        public async Task<ServiceResponse> DeleteAsync(int id)
        {
            var entity = await _categoryRepository
                .FindByIdAsync(id);

            if (entity == null)
            {
                return ServiceResponse.Error($"Категорію з id {id} не знайдено");
            }

            bool result = await _categoryRepository.DeleteAsync(entity.Id);

            if (result)
            {
                return ServiceResponse.Success($"Категорію {entity.Name} успішно видалено");
            }

            return ServiceResponse.Error($"Не вдалося видалити категорію");
        }

        public async Task<ServiceResponse> GetAllAsync()
        {
            var entities = await _categoryRepository
                .GetAll()
                .ToListAsync();

            var dtos = _mapper.Map<List<CategoryDto>>(entities);

            return ServiceResponse.Success("Категорії отримано", dtos);
        }

        public async Task<ServiceResponse> GetByIdAsync(int id)
        {
            var entity = await _categoryRepository.FindByIdAsync(id);

            if (entity != null)
            {
                var dto = _mapper.Map<CategoryDto>(entity);
                return ServiceResponse.Success($"Категорію {entity.Name} отримано", dto);
            }

            return ServiceResponse.Error("Категорію не знайдено");
        }

        public async Task<ServiceResponse> GetByNameAsync(string name)
        {
            var entity = await _categoryRepository.FindByNameAsync(name);

            if (entity != null)
            {
                var dto = _mapper.Map<CategoryDto>(entity);
                return ServiceResponse.Success($"Категорію {entity.Name} отримано", dto);
            }

            return ServiceResponse.Error($"Категорію {name} не знайдено");
        }

        public async Task<ServiceResponse> UpdateAsync(UpdateCategoryDto dto)
        {
            if (!_categoryRepository.IsUniqueName(dto.Name))
            {
                return ServiceResponse.Error($"Категорія з іменем {dto.Name} вже існує");
            }

            var entity = await _categoryRepository.FindByIdAsync(dto.Id);

            if (entity == null)
            {
                return ServiceResponse.Error($"Категорію з id {dto.Id} не знайдено");
            }

            entity = _mapper.Map(dto, entity);

            bool result = await _categoryRepository.UpdateAsync(entity);

            if (result)
            {
                return ServiceResponse.Success($"Категорію {entity.Name} успішно оновлено", dto);
            }

            return ServiceResponse.Error($"Не вдалося оновити категорію", dto);
        }
    }
}
