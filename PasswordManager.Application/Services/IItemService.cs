using PasswordManager.Application.DTOs;

namespace PasswordManager.Application.Services
{
    public interface IItemService
    {
        Task<IEnumerable<ItemDTO>> GetAllByGroupAsync(int groupID);
        Task<ItemDTO> CreateAsync(ItemDTO item);
        Task<ItemDTO> UpdateAsync(ItemDTO item);
        Task<ItemDTO> DeleteAsync(int id);
    }
}
