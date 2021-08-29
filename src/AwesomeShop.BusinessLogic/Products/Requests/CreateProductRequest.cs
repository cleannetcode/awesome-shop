using System;

namespace AwesomeShop.BusinessLogic.Products.Requests
{
    public class CreateProductRequest : ProductRequestBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}