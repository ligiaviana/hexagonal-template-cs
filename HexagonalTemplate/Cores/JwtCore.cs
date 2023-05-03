using HexagonalTemplate.Models.Dtos;
using HexagonalTemplate.Ports.Ins;

namespace HexagonalTemplate.Cores
{
    public class JwtCore : IJwtCore
    {
        public string GenerateToken(UserDto userDto)
        {
            throw new NotImplementedException();
        }

        public void Match(string passwordRequest, string passwordDb)
        {
            throw new NotImplementedException();
        }
    }
}
