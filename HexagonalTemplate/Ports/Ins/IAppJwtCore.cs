using HexagonalTemplate.Models.Entities;

namespace HexagonalTemplate.Ports.Ins
{
    public interface IAppJwtCore
    {
        public string GenerateToken(AppEntity appEntity);
    }
}
