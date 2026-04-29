using AutoMapper;
using PasswordManager.Application.DTOs;
using PasswordManager.Domain.Entities;
using PasswordManager.Domain.Repositories;

namespace PasswordManager.Application.Services.Impl
{
    public class ItemServiceImpl(IMapper mapper, IGroupRepository groupRepository, IItemRepository itemRepository) : IItemService
    {
        private readonly IMapper mapper = mapper;
        private readonly IGroupRepository groupRepository = groupRepository;
        private readonly IItemRepository itemRepository = itemRepository;

        public async Task<ItemDTO> CreateAsync(ItemDTO item)
        {
            var entity = mapper.Map<Item>(item);
            var resultEntity = await itemRepository.CreateAsync(entity);
            var result = mapper.Map<ItemDTO>(resultEntity);
            return result;
        }

        public async Task<ItemDTO> DeleteAsync(int id)
        {
            var entity = await itemRepository.GetById(id);
            var resultEntity = await itemRepository.DeleteAsync(entity);
            var result = mapper.Map<ItemDTO>(resultEntity);
            return result;
        }

        public async Task<IEnumerable<ItemDTO>> GetAllByGroupAsync(int groupID)
        {
            var group = await groupRepository.GetById(groupID);
            var groups = await itemRepository.GetAllByGroupAsync(group);
            var result = mapper.Map<IEnumerable<ItemDTO>>(groups);
            return result;
        }

        public async Task<ItemDTO> UpdateAsync(ItemDTO item)
        {
            var entity = mapper.Map<Item>(item);
            var resultEntity = await itemRepository.UpdateAsync(entity);
            var result = mapper.Map<ItemDTO>(resultEntity);
            return result;
        }
    }
}
