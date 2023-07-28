using HexagonalTemplate.Models.Entities;

namespace HexagonalTemplate.Ports.Outs
{
    public interface IDeleteUserUseCase
    {
        public void DeleteByEmail(string email);
    }
}
