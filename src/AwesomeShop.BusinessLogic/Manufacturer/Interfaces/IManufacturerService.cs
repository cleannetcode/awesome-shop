using AwesomeShop.BusinessLogic.Manufacturer.Requests;
using AwesomeShop.BusinessLogic.Manufacturer.Responses;
using AwesomeShop.BusinessLogic.Products.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AwesomeShop.BusinessLogic.Manufacturer.Interfaces
{
    public interface IManufacturerService
    {
        Task<ManufacturerListViewModel> GetAllManufacturersAsync(GetAllManufacturersRequest request, CancellationToken cancellationToken = default);

        Task<ManufacturerViewModel> FindByIdManufacturerAsync(Guid id, CancellationToken cancellationToken = default);

        Task CreateManufacturerAsync(CreateManufacturerRequest request, CancellationToken cancellationToken = default);

        Task UpdateManufacturerAsync(Guid manufacturerId, UpdateManufacturerRequest request, CancellationToken cancellationToken);

        Task DeleteManufacturerAsync(Guid manufacturerId, CancellationToken cancellationToken);
    }
}
