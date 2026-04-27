using PasswordManager.Domain.Validation;

namespace PasswordManager.Domain.Entities
{
    public sealed class Group : Entity
    {
        public string Title { get; private set; } = string.Empty;

        public Group(string title)
        {
            Validate(title);
        }

        public Group(int id, string title) : this(title)
        {
            DomainExceptionValidation.When(id < 0, ValidationCodes.InvalidId);

            Id = id;
        }

        private void Validate(string title)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(title), ValidationCodes.InvalidTitle);

            Title = title;
        }
    }
}
