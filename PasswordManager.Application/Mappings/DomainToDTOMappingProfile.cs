using AutoMapper;
using PasswordManager.Application.DTOs;
using PasswordManager.Domain.Entities;

namespace PasswordManager.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Group, GroupDTO>().ReverseMap();
        }
    }
}
