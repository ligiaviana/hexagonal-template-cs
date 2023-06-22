using HexagonalTemplate.Models.Entities;

namespace HexagonalTemplate.Ports.Ins
{
    public interface IAppUseCase
    {
        public string GenerateNewApp(AppEntity appEntity);
    }
}
