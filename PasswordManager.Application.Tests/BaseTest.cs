using AutoMapper;
using Microsoft.Extensions.Logging.Abstractions;
using PasswordManager.Application.Mappings;

namespace PasswordManager.Application.Tests
{
    public abstract class BaseTest
    {
        protected readonly IMapper mapper;

        protected BaseTest()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToDTOMappingProfile());
            }, NullLoggerFactory.Instance);

            mapper = mockMapper.CreateMapper();
        }
    }
}
