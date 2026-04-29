using PasswordManager.Domain.Entities;

namespace PasswordManager.Domain.Repositories
{
    public interface IItemRepository
    {
        Task<Item> GetById(int id);
        Task<IEnumerable<Item>> GetAllByGroupAsync(Group group);

        Task<Item> CreateAsync(Item item);
        Task<Item> UpdateAsync(Item item);
        Task<Item> DeleteAsync(Item item);
    }
}
