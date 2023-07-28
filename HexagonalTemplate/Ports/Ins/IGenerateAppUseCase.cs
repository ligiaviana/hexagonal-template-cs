using HexagonalTemplate.Models.Entities;

namespace HexagonalTemplate.Ports.Ins
{
    public interface IGenerateAppUseCase
    {
        public IDictionary<string, object> GenerateNewApp(AppEntity appEntity);
    }
}
