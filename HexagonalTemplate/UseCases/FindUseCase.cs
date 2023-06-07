using HexagonalTemplate.Models.Entities;
using HexagonalTemplate.Ports.Ins;
using HexagonalTemplate.Ports.Outs;
using Microsoft.AspNetCore.Mvc;

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

            var user = userRepository.FindByEmail(email);

            if (user == null)
            {
                throw new ArgumentNullException("User not found");
            }
            return user;
        }
    }
}
