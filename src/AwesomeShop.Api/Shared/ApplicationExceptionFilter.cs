using AwesomeShop.BusinessLogic.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AwesomeShop.Api.Shared
{
    public class ApplicationExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = context.Exception switch
            {
                ResourceNotFoundException => new NotFoundResult(),
                ValidationException => new BadRequestResult(),
                BusinessLogicException => new BadRequestResult(),
                _ => context.Result
            };
        }
    }
}