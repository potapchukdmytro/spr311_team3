using AutoMapper;
using team3.DAL.Entities;
using team3.DTOs.Category;

namespace team3.BLL.MapperProfiles
{
    public class CategoryMapperProfile : Profile
    {
        public CategoryMapperProfile()
        {
            //CreateCategoryDTO -> CategoryEntity
            CreateMap<CreateCategoryDto, CategoryEntity>();

            //UpdateCategoryDTO -> CategoryEntity
            CreateMap<UpdateCategoryDto, CategoryEntity>();

            //CategoryEntity -> CategoryDTO
            CreateMap<CategoryEntity, CategoryDto>();
        }
    }
}
