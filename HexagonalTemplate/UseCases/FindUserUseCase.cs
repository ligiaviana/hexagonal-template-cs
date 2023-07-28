using HexagonalTemplate.Models.Entities;
using HexagonalTemplate.Ports.Ins;
using HexagonalTemplate.Ports.Outs;

namespace HexagonalTemplate.UseCases
{
    public class FindUserUseCase : IFindUserUseCase
    {
        IUserRepository userRepository;

        public FindUserUseCase (IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public UserEntity GetUserByEmail(string email)
        {

            var user = userRepository.FindByEmail(email);

            if (user == null)
            {
                throw new ArgumentNullException("User not found");
            }
            return user;
        }
    }
}
