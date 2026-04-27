using PasswordManager.Domain.Entities;

namespace PasswordManager.Domain.Repositories
{
    public interface IGroupRepository
    {
        Task<IEnumerable<Group>> GetAllAsync();
        Task<Group> CreateAsync(Group group);
        Task<Group> UpdateAsync(Group group);
        Task<Group> DeleteAsync(int id);
    }
}
