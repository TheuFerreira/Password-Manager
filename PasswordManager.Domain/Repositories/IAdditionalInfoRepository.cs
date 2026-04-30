using PasswordManager.Domain.Entities;

namespace PasswordManager.Domain.Repositories
{
    public interface IAdditionalInfoRepository
    {
        Task<IEnumerable<AdditionalInfo>> GetAllByItemAsync(int itemId);
        Task<AdditionalInfo> CreateAsync(AdditionalInfo additionalInfo);
        Task<AdditionalInfo> UpdateAsync(AdditionalInfo additionalInfo);
        Task<AdditionalInfo> DeleteAsync(AdditionalInfo additionalInfo);
    }
}
