using HexagonalTemplate.Models.Dtos;
using HexagonalTemplate.Models.Entities;

namespace HexagonalTemplate.Ports.Ins
{
    public interface IFindUseCase
    {
        public UserEntity GetUserByEmail(string email);
    }
}
