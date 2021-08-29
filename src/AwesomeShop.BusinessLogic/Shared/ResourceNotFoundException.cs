namespace AwesomeShop.BusinessLogic.Shared
{
    public class ResourceNotFoundException : BusinessLogicException
    {
        public override ErrorType Type => ErrorType.NotFound;
    }
}