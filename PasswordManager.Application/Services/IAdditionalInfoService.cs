using PasswordManager.Application.DTOs;

namespace PasswordManager.Application.Services
{
    public interface IAdditionalInfoService
    {
        Task<IEnumerable<AdditionalInfoDTO>> Save(int itemId, IEnumerable<AdditionalInfoDTO> infos);
    }
}
