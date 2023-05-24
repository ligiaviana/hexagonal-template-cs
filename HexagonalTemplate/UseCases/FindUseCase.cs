using HexagonalTemplate.Models.Entities;
using HexagonalTemplate.Ports.Ins;
using HexagonalTemplate.Ports.Outs;

namespace HexagonalTemplate.UseCases
{
    public class FindUseCase : IFindUseCase
    {
        IUserRepository userRepository;

        public FindUseCase (IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public UserEntity GetUserByEmail(string email)
        {
            var userEntity = new UserEntity { Email = email };
            var user = userRepository.FindByEmail(userEntity);
            return user;
        }
    }
}
