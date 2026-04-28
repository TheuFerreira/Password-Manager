using FluentAssertions;
using PasswordManager.Domain.Entities;
using PasswordManager.Domain.Validation;

namespace PasswordManager.Domain.Tests
{
    public sealed class GroupTest
    {
        [Fact]
        public void Create_With_ValidParameters()
        {
            Action a1 = () => new Group("Group 01");
            a1.Should().NotThrow<DomainExceptionValidation>();

            Action a2 = () => new Group(1, "Group 02");
            a2.Should().NotThrow<DomainExceptionValidation>();

            Action a3 = () => new Group(0, "Group 03");
            a3.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void Create_With_InvalidParameters()
        {
            Action a1 = () => new Group("");
            a1.Should().Throw<DomainExceptionValidation>();

            Action a2 = () => new Group(string.Empty);
            a2.Should().Throw<DomainExceptionValidation>();

            Action a3 = () => new Group(null);
            a3.Should().Throw<DomainExceptionValidation>();

            Action a4 = () => new Group(-1, "Group 02");
            a4.Should().Throw<DomainExceptionValidation>();
        }

        [Fact]
        public void Update_With_ValidParameters()
        {
            Group group = new(0, "Group");

            Action a1 = () => group.Update(0, "Group Updated");
            a1.Should().NotThrow<DomainExceptionValidation>();

            Action a2 = () => group.Update(1, "Group Updated 2");
            a2.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void Update_With_InvalidParameters()
        {
            Group group = new(0, "Group");

            Action a1 = () => group.Update(-1, "Group Updated");
            a1.Should().Throw<DomainExceptionValidation>();

            Action a2 = () => group.Update(1, string.Empty);
            a2.Should().Throw<DomainExceptionValidation>();

            Action a3 = () => group.Update(1, null);
            a3.Should().Throw<DomainExceptionValidation>();
        }
    }
}
