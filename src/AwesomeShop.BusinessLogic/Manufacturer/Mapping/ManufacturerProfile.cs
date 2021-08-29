using AutoMapper;
using AwesomeShop.BusinessLogic.Manufacturer.Requests;
using AwesomeShop.BusinessLogic.Manufacturer.Responses;
using AwesomeShop.Data.Models;

namespace AwesomeShop.BusinessLogic.Manufacturer.Mapping
{
    public class ManufacturerProfile : Profile
    {
        public ManufacturerProfile()
        {
            CreateMap<CreateManufacturerRequest, Data.Models.Manufacturer>();
            CreateMap<ManufacturerRequestBase.DeliveryCountryDto, Data.Models.Manufacturer>();
            CreateMap<UpdateManufacturerRequest, Data.Models.Manufacturer>();
            CreateMap<ManufacturerRequestBase, Data.Models.Manufacturer>();
            CreateMap<Data.Models.Manufacturer, ManufacturerViewModel>();
        }
    }
}
