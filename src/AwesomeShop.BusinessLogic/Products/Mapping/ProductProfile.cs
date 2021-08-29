using AutoMapper;
using AwesomeShop.BusinessLogic.Products.Requests;
using AwesomeShop.BusinessLogic.Products.Responses;
using AwesomeShop.Data.Models;

namespace AwesomeShop.BusinessLogic.Products.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductRequest, Product>();
            CreateMap<ProductRequestBase.DeliveryCountryDto, Data.Models.DeliveryCountry>();
            CreateMap<UpdateProductRequest, Product>();
            CreateMap<ProductRequestBase, Product>();

            CreateMap<Product, ProductViewModel>();
            CreateMap<Category, ProductViewModel.CategoryDto>();
            CreateMap<Data.Models.DeliveryCountry, ProductViewModel.DeliveryCountryDto>();
        }
    }
}