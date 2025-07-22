using AutoMapper;
using TechZone.Ecommerce.Domain.Entities;
using TechZone.Ecommerce.DTOs.DTOs;
using TechZone.Ecommerce.UseCases.Categories.Commands.CreateCategoryCommand;
using TechZone.Ecommerce.UseCases.Categories.Commands.UpdateCategoryCommand;
using TechZone.Ecommerce.UseCases.Products.Commands.CreateProductCommand;
using TechZone.Ecommerce.UseCases.Products.Commands.UpdateProductCommand;
using TechZone.Ecommerce.UseCases.SubCategories.Commands.CreateSubCategoryCommand;
using TechZone.Ecommerce.UseCases.SubCategories.Commands.UpdateSubCategoryCommand;
using TechZone.Ecommerce.UseCases.Users.Commands.CreateUserCommand;

namespace TechZone.Ecommerce.UseCases.Common.Mappings
{
    internal sealed class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserCommand>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommand>().ReverseMap();

            CreateMap<SubCategory, SubCategoryDto>().ReverseMap();
            CreateMap<SubCategory, CreateSubCategoryCommand>().ReverseMap();
            CreateMap<SubCategory, UpdateSubCategoryCommand>().ReverseMap();

            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();
        }
    }
}
