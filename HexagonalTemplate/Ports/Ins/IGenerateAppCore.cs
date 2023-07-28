using HexagonalTemplate.Models.Entities;

namespace HexagonalTemplate.Ports.Ins
{
    public interface IGenerateAppCore
    {
        public void ValidateApp(AppEntity appEntity);

        public IDictionary<string, object> CreateAppGenerationResult(int appId, string appToken);
    }
}
