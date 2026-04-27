using PasswordManager.Domain.Validation;

namespace PasswordManager.Domain.Entities
{
    public sealed class Group : Entity
    {
        public string Name { get; private set; } = string.Empty;

        public Group(string name)
        {
            Validate(name);
        }

        public Group(int id, string name) : this(name)
        {
            DomainExceptionValidation.When(id < 0, ValidationCodes.InvalidId);

            Id = id;
        }

        private void Validate(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), ValidationCodes.InvalidName);

            Name = name;
        }
    }
}
