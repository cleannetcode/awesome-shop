using AutoMapper;
using AwesomeShop.BusinessLogic.Categories.Requests;
using AwesomeShop.BusinessLogic.Categories.Responses;
using AwesomeShop.Data.Models;

namespace AwesomeShop.BusinessLogic.Categories.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryRequest, Category>();
            CreateMap<UpdateCategoryRequest, Category>();
            CreateMap<CategoryRequestBase, Category>();

            CreateMap<Category, CategoryViewModel>();
        }
    }
}