using System.ComponentModel.DataAnnotations;

namespace PasswordManager.Application.DTOs
{
    public class ItemDTO
    {
        public int Id { get; set; }

        [Required]
        public required string Title { get; set; }

        [Required]
        public required string Password { get; set; }
    }
}
