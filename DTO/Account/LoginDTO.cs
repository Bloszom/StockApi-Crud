using System.ComponentModel.DataAnnotations;

namespace morningclassonapi.DTO.Account
{
    public class LoginDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
