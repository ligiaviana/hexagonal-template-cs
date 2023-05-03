using HexagonalTemplate.Models.Dtos;

namespace HexagonalTemplate.Models.Entities
{
    public class UserEntity : UserDto
    {
        public int UserId { get; set; }
        public string CPF { get; set; }
    }
}
