using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(8, MinimumLength=4, ErrorMessage="Needs to be between 4 and 8 characters")]
        public string Password { get; set; }
    }
}