using AutoMapper;
using PasswordManager.Application.DTOs;
using PasswordManager.Domain.Entities;
using PasswordManager.Domain.Repositories;

namespace PasswordManager.Application.Services.Impl
{
    public class GroupServiceImpl(IMapper mapper, IGroupRepository groupRepository) : IGroupService
    {
        private readonly IMapper mapper = mapper;
        private readonly IGroupRepository groupRepository = groupRepository;

        public async Task<IEnumerable<GroupDTO>> GetAllAsync()
        {
            var entities = await groupRepository.GetAllAsync();
            var dtos = mapper.Map<IEnumerable<GroupDTO>>(entities);
            return dtos;
        }

        public async Task<GroupDTO> CreateAsync(GroupDTO group)
        {
            var entity = mapper.Map<Group>(group);
            var entityResult = await groupRepository.CreateAsync(entity);
            var dtoResult = mapper.Map<GroupDTO>(entityResult);
            return dtoResult;
        }

        public async Task<GroupDTO> UpdateAsync(GroupDTO group)
        {
            var entity = mapper.Map<Group>(group);
            var entityResult = await groupRepository.UpdateAsync(entity);
            var dtoResult = mapper.Map<GroupDTO>(entityResult);
            return dtoResult;
        }

        public async Task<GroupDTO> DeleteAsync(int id)
        {
            var entity = await groupRepository.GetById(id);
            var entityResult = await groupRepository.DeleteAsync(entity);
            var dtoResult = mapper.Map<GroupDTO>(entityResult);
            return dtoResult;
        }
    }
}
