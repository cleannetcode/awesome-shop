using System;

namespace AwesomeShop.BusinessLogic.Shared.Responses
{
    public class BaseListViewModel
    {
        public int? TotalCount { get; set; }

        public int? PageSize { get; set; }

        public int RequestedPageSize { get; set; } = 20;

        public int PageNumber { get; set; } = 1;

        public int? TotalPages =>
            (int)Math.Ceiling((decimal)TotalCount.GetValueOrDefault() / RequestedPageSize);

        public bool? HasPrevious => PageNumber > 1;

        public bool? HasNext => PageNumber < TotalPages;
    }
}