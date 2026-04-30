using PasswordManager.Domain.Entities;

namespace PasswordManager.Domain.Repositories
{
    public interface IAdditionalInfoRepository
    {
        Task<IEnumerable<AdditionalInfo>> GetAllByItemAsync(Item item);
        Task<AdditionalInfo> CreateAsync(AdditionalInfo additionalInfo);
        Task<AdditionalInfo> DeleteAsync(AdditionalInfo additionalInfo);
    }
}
