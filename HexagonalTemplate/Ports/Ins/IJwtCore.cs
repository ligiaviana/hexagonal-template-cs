using HexagonalTemplate.Models.Dtos;
using HexagonalTemplate.Models.Entities;

namespace HexagonalTemplate.Ports.Ins
{
    public interface IJwtCore
    {
        void Match(string passwordRequest, string passwordDb);

        public string GenerateToken(UserEntity userEntity);
    }
}
