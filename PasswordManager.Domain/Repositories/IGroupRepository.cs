using PasswordManager.Domain.Entities;

namespace PasswordManager.Domain.Repositories
{
    public interface IGroupRepository
    {
        Task<Group> GetById(int id);
        Task<IEnumerable<Group>> GetAllAsync();

        Task<Group> CreateAsync(Group group);
        Task<Group> UpdateAsync(Group group);
        Task<Group> DeleteAsync(Group group);
    }
}
