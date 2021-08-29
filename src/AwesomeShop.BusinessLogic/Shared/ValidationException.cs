namespace AwesomeShop.BusinessLogic.Shared
{
    public class ValidationException : BusinessLogicException
    {
        public ValidationException(string validationMessage)
        {
            ValidationMessage = validationMessage;
        }
        
        public string ValidationMessage { get; }
        
        public override ErrorType Type => ErrorType.Invalid;

    }
}