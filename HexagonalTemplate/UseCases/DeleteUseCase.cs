using HexagonalTemplate.Models.Entities;
using HexagonalTemplate.Ports.Outs;

namespace HexagonalTemplate.UseCases
{
    public class DeleteUseCase : IDeleteUseCase
    {
        IUserRepository userRepository;

        public DeleteUseCase(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void DeleteByEmail(string email)
        {
            var user = userRepository.FindByEmail(email);

            if (user == null)
            {
                throw new ArgumentNullException("User not found");
            }

            userRepository.DeleteByEmail(email);
        }
    }
}
