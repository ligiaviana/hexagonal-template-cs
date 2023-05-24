using HexagonalTemplate.Models.Dtos;
using System.ComponentModel.DataAnnotations;

namespace HexagonalTemplate.Models.Entities
{
    public class UserEntity : UserDto
    {
        [Key]
        public int UserId { get; set; }
        public string CPF { get; set; }
    }
}
