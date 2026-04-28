using FluentAssertions;
using PasswordManager.Domain.Entities;
using PasswordManager.Domain.Validation;

namespace PasswordManager.Domain.Tests
{
    public sealed class AdditionalInfoTest
    {
        [Fact]
        public void Create_With_ValidParameters()
        {
            Action a1 = () => new AdditionalInfo("Title", "Value");
            a1.Should().NotThrow<DomainExceptionValidation>();

            Action a2 = () => new AdditionalInfo(1, "Title", "Value");
            a2.Should().NotThrow<DomainExceptionValidation>();

            Action a3 = () => new AdditionalInfo(0, "Title", "Value");
            a3.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void Create_With_InvalidParameters()
        {
            Action a1 = () => new AdditionalInfo("", "Value");
            a1.Should().Throw<DomainExceptionValidation>();

            Action a2 = () => new AdditionalInfo(string.Empty, "Value");
            a2.Should().Throw<DomainExceptionValidation>();

            Action a3 = () => new AdditionalInfo(null, "Value");
            a3.Should().Throw<DomainExceptionValidation>();

            Action a4 = () => new AdditionalInfo("Title", "");
            a4.Should().Throw<DomainExceptionValidation>();

            Action a5 = () => new AdditionalInfo("Title", string.Empty);
            a5.Should().Throw<DomainExceptionValidation>();

            Action a6 = () => new AdditionalInfo("Title", null);
            a6.Should().Throw<DomainExceptionValidation>();

            Action a7 = () => new AdditionalInfo(-1, "Title", "Ola");
            a7.Should().Throw<DomainExceptionValidation>();
        }

        [Fact]
        public void Update_With_ValidParameters()
        {
            AdditionalInfo additionalInfo = new("Title", "Value");

            Action a1 = () => additionalInfo.Update(1, "Title", "Value");
            a1.Should().NotThrow<DomainExceptionValidation>();

            Action a2 = () => additionalInfo.Update(0, "Title", "Value");
            a2.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void Update_With_InvalidParameters()
        {
            AdditionalInfo additionalInfo = new("Title", "Value");

            Action a1 = () => additionalInfo.Update(-1, "Title", "Value");
            a1.Should().Throw<DomainExceptionValidation>();

            Action a2 = () => additionalInfo.Update(0, string.Empty, "Value");
            a2.Should().Throw<DomainExceptionValidation>();

            Action a3 = () => additionalInfo.Update(0, "Title", "");
            a3.Should().Throw<DomainExceptionValidation>();
        }
    }
}
