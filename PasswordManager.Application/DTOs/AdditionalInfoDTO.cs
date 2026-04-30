using System.ComponentModel.DataAnnotations;

namespace PasswordManager.Application.DTOs
{
    public class AdditionalInfoDTO
    {
        public int Id { get; set; }

        [Required]
        public required string Title { get; set; }

        [Required]
        public required string Value { get; set; }
    }
}
