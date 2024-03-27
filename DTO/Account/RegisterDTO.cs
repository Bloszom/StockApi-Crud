using System.ComponentModel.DataAnnotations;

namespace morningclassonapi.DTO.Account
{
    public class RegisterDTO
    {
        [Required]
        public string? Username { get; set; }
        
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
