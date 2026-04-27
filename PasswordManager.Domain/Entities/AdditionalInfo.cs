using PasswordManager.Domain.Validation;

namespace PasswordManager.Domain.Entities
{
    public sealed class AdditionalInfo
    {
        public int Id { get; private set; }
        public string Title { get; private set; } = string.Empty;
        public string Value { get; private set; } = string.Empty;

        public int ItemId { get; set; }
        public Item? Item { get; set; }

        public AdditionalInfo(string title, string value)
        {
            Validate(title, value);
        }

        public AdditionalInfo(int id, string title, string value) : this(title, value)
        {
            DomainExceptionValidation.When(id < 0, ValidationCodes.InvalidId);
            Id = id;
        }

        private void Validate(string title, string value)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(title), ValidationCodes.InvalidTitle);
            DomainExceptionValidation.When(string.IsNullOrEmpty(value), ValidationCodes.InvalidValue);

            Title = title;
            Value = value;
        }
    }
}
