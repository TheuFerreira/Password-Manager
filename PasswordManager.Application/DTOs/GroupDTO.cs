using System.ComponentModel.DataAnnotations;

namespace PasswordManager.Application.DTOs
{
    public class GroupDTO
    {
        public int Id { get; set; }

        [Required]
        public required string Title { get; set; }
    }
}
