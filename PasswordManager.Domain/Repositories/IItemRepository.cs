using PasswordManager.Domain.Entities;

namespace PasswordManager.Domain.Repositories
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetAllByGroupAsync(int groupId);
        Task<Item> CreateAsync(Item item);
        Task<Item> UpdateAsync(Item item);
        Task<Item> DeleteAsync(int id);
    }
}
