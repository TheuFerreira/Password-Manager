namespace PasswordManager.Domain.Entities
{
    public sealed class Item : Entity
    {
        public string Title { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;

        public int GroupId { get; set; }
        public Group? Group { get; set; }
    }
}
