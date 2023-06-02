using HexagonalTemplate.Models.Dtos;
using HexagonalTemplate.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HexagonalTemplate.Ports.Ins
{
    public interface IFindUseCase
    {
        public UserEntity GetUserByEmail(string email);
    }
}
