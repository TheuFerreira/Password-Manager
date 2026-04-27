namespace PasswordManager.Domain.Validation
{
    public sealed class DomainExceptionValidation(ValidationCodes validationCode, string message) : Exception(message)
    {
        public ValidationCodes ValidationCode { get; private set; } = validationCode;

        public static void When(bool hasError, ValidationCodes validationCode, string message = "DomainExceptionValidation")
        {
            if (hasError)
                throw new DomainExceptionValidation(validationCode, message);
        }
    }
}
