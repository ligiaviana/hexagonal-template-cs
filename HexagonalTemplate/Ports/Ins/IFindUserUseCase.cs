using HexagonalTemplate.Models.Dtos;
using HexagonalTemplate.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HexagonalTemplate.Ports.Ins
{
    public interface IFindUserUseCase
    {
        public UserEntity GetUserByEmail(string email);
    }
}
