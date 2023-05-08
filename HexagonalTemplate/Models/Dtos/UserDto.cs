using System.ComponentModel.DataAnnotations;

namespace HexagonalTemplate.Models.Dtos
{
    public class UserDto
    {
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
