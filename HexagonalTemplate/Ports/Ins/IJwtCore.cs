using HexagonalTemplate.Models.Dtos;

namespace HexagonalTemplate.Ports.Ins
{
    public interface IJwtCore
    {
        void Match(string passwordRequest, string passwordDb);

        string GenerateToken(UserDto userDto);
    }
}
