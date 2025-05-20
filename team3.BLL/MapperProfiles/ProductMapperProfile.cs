using AutoMapper;
using team3.DAL.Entities;
using team3.DTOs.Category;
using team3.DTOs.Product;

namespace team3.BLL.MapperProfiles
{
    public class ProductMapperProfile : Profile
    {
        public ProductMapperProfile()
        {
            //CreateProductDto => ProductEntity
            CreateMap<CreateProductDto, ProductEntity>();

            //UpdateProductDto => ProductEntity
            CreateMap<UpdateProductDto, ProductEntity>();

            //ProductEntity => ProductDto
            CreateMap<ProductEntity, ProductDto>();
        }
    }
}
