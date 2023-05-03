using HexagonalTemplate.Models.Dtos;
using HexagonalTemplate.Ports.Ins;
using HexagonalTemplate.Ports.Outs;


namespace HexagonalTemplate.Adapters.SqliteAdapters
{
    public class UserRepository : IUserRepository
    {
        public UserDto Create(UserDto userDto)
        {
            if (userDto == null)
            {
                throw new ArgumentNullException(nameof(userDto));
            }

            return userDto;
        }

        public string FindByEmail(UserDto userDto)
        {
            return userDto.Email;
        }
    }
}
