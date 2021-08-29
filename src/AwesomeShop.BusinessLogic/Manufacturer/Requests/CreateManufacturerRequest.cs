using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeShop.BusinessLogic.Manufacturer.Requests
{
    public class CreateManufacturerRequest
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
