using FluentAssertions;
using PasswordManager.Domain.Entities;
using PasswordManager.Domain.Validation;

namespace PasswordManager.Domain.Tests
{
    public sealed class ItemTest
    {
        [Fact]
        public void Create_With_ValidParameters()
        {
            Action a1 = () => new Item("Title", "Pass");
            a1.Should().NotThrow<DomainExceptionValidation>();

            Action a2 = () => new Item(0, "Title", "Password");
            a2.Should().NotThrow<DomainExceptionValidation>();

            Action a3 = () => new Item(1, "Title", "Pass");
            a3.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void Create_With_InvalidParameters()
        {
            Action a1 = () => new Item(string.Empty, "Password");
            a1.Should().Throw<DomainExceptionValidation>();

            Action a2 = () => new Item("", "Password");
            a2.Should().Throw<DomainExceptionValidation>();

            Action a3 = () => new Item("Title", string.Empty);
            a3.Should().Throw<DomainExceptionValidation>();

            Action a4 = () => new Item("Title", "");
            a4.Should().Throw<DomainExceptionValidation>();

            Action a5 = () => new Item(-1, "Title", "Pass");
            a5.Should().Throw<DomainExceptionValidation>();
        }

        [Fact]
        public void Update_With_ValidParameters()
        {
            Item item = new("Title", "Password");

            Action a1 = () => item.Update(0, "Title", "Password", 1, []);
            a1.Should().NotThrow<DomainExceptionValidation>();

            Action a2 = () => item.Update(1, "Title", "Password", 2, []);
            a2.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void Update_With_InvalidParameters()
        {
            Item item = new("Title", "Password");

            Action a1 = () => item.Update(-1, "Title", "Password", 1, []);
            a1.Should().Throw<DomainExceptionValidation>();

            Action a2 = () => item.Update(1, string.Empty, "Password", 1, []);
            a2.Should().Throw<DomainExceptionValidation>();

            Action a3 = () => item.Update(1, "Title", string.Empty, 1, []);
            a3.Should().Throw<DomainExceptionValidation>();

            Action a4 = () => item.Update(1, "Title", "Password", -1, []);
            a4.Should().Throw<DomainExceptionValidation>();
        }
    }
}
