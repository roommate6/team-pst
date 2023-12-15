using System.ComponentModel.DataAnnotations;

namespace YummyGen.Domain.Dto
{
    public class LoginDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
