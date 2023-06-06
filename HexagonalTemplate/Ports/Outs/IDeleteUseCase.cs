using HexagonalTemplate.Models.Entities;

namespace HexagonalTemplate.Ports.Outs
{
    public interface IDeleteUseCase
    {
        public void DeleteByEmail(string email);
    }
}
