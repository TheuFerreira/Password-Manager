using PasswordManager.Domain.Validation;

namespace PasswordManager.Domain.Entities
{
    public sealed class Item : Entity
    {
        public string Title { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;

        public int GroupId { get; set; }
        public Group? Group { get; set; }

        public IEnumerable<int> AdditionalInfosIds { get; set; } = [];
        public IEnumerable<AdditionalInfo> AdditionalInfos { get; set; } = [];

        public Item(string title, string password)
        {
            Validate(title, password);
        }

        public Item(int id, string title, string password) : this(title, password)
        {
            DomainExceptionValidation.When(id < 0, ValidationCodes.InvalidId);
            Id = id;
        }

        private void Validate(string title, string password)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(title), ValidationCodes.InvalidTitle);
            DomainExceptionValidation.When(string.IsNullOrEmpty(password), ValidationCodes.InvalidPassword);

            Title = title;
            Password = password;
        }
    }
}
