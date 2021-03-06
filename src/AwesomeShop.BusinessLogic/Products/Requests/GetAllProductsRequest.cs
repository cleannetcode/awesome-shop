namespace AwesomeShop.BusinessLogic.Products.Requests
{
    public class GetAllProductsRequest
    {
        public string Filters { get; set; }

        public string Sorts { get; set; }

        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 20;

        public bool IsNeedTotalCount { get; set; } = false;
    }
}