using System;

namespace AwesomeShop.BusinessLogic.Shared
{
    public abstract class BusinessLogicException : ApplicationException
    {
        public abstract ErrorType Type { get; }
    }
}