using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeShop.BusinessLogic.Manufacturer.Requests
{
    public class GetAllManufacturersRequest
    {
        public string Filters { get; set; }

        public string Sorts { get; set; }

        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 20;

        public bool IsNeedTotalCount { get; set; } = false;
    }
}
