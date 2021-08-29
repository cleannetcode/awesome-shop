using System.Collections.Generic;
using AwesomeShop.BusinessLogic.Shared.Responses;

namespace AwesomeShop.BusinessLogic.Products.Responses
{
    public class ProductListViewModel : BaseListViewModel
    {
        public List<ProductViewModel> Items { get; set; }
    }
}