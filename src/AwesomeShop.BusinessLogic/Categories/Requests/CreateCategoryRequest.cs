using System;

namespace AwesomeShop.BusinessLogic.Categories.Requests
{
    public class CreateCategoryRequest : CategoryRequestBase
    {
        public Guid Id { get; set; }
    }
}