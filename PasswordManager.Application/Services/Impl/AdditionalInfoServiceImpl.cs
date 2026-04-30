using AutoMapper;
using PasswordManager.Application.DTOs;
using PasswordManager.Domain.Entities;
using PasswordManager.Domain.Repositories;

namespace PasswordManager.Application.Services.Impl
{
    public class AdditionalInfoServiceImpl(IMapper mapper, IItemRepository itemRepository, IAdditionalInfoRepository additionalInfoRepository) : IAdditionalInfoService
    {
        private readonly IMapper mapper = mapper;
        private readonly IItemRepository itemRepository = itemRepository;
        private readonly IAdditionalInfoRepository additionalInfoRepository = additionalInfoRepository;

        public async Task<IEnumerable<AdditionalInfoDTO>> Save(int itemId, IEnumerable<AdditionalInfoDTO> newInfos)
        {
            var item = await itemRepository.GetById(itemId);
            var infos = await additionalInfoRepository.GetAllByItemAsync(item);
            foreach (var info in infos)
            {
                await additionalInfoRepository.DeleteAsync(info);
            }

            IEnumerable<AdditionalInfoDTO> dtos = [];
            foreach (var info in newInfos)
            {
                var entity = mapper.Map<AdditionalInfo>(info);
                var resultEntity = await additionalInfoRepository.CreateAsync(entity);

                var result = mapper.Map<AdditionalInfoDTO>(resultEntity);
                _ = dtos.Append(result);
            }

            return dtos;
        }
    }
}
