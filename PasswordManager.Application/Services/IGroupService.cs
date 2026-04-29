using PasswordManager.Application.DTOs;

namespace PasswordManager.Application.Services
{
    public interface IGroupService
    {
        Task<IEnumerable<GroupDTO>> GetAllAsync();
        Task<GroupDTO> CreateAsync(GroupDTO group);
        Task<GroupDTO> UpdateAsync(GroupDTO group);
        Task<GroupDTO> DeleteAsync(int id);
    }
}
