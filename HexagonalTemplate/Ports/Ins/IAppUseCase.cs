using HexagonalTemplate.Models.Entities;

namespace HexagonalTemplate.Ports.Ins
{
    public interface IAppUseCase
    {
        public IDictionary<string, object> GenerateNewApp(AppEntity appEntity);
    }
}
