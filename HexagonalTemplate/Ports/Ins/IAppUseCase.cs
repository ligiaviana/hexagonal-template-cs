using HexagonalTemplate.Models.Entities;

namespace HexagonalTemplate.Ports.Ins
{
    public interface IAppUseCase
    {
        public dynamic GenerateNewApp(AppEntity appEntity);
    }
}
