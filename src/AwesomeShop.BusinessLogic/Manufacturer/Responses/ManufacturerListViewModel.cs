using AwesomeShop.BusinessLogic.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeShop.BusinessLogic.Manufacturer.Responses
{
    public class ManufacturerListViewModel : BaseListViewModel
    {
        public List<ManufacturerViewModel> Items { get; set; }
    }
}
