using HexagonalTemplate.Models.Entities;
using HexagonalTemplate.Ports.Ins;

namespace HexagonalTemplate.Cores
{
    public class GenerateAppCore : IGenerateAppCore
    {
        public void ValidateApp(AppEntity appEntity)
        {
            if (appEntity == null)
                throw new ArgumentNullException(nameof(appEntity));

            if (string.IsNullOrEmpty(appEntity.AppName))
                throw new ArgumentNullException("AppName should be informed.");
        }

        public IDictionary<string, object> CreateAppGenerationResult(int appId, string appToken)
        {
            return new Dictionary<string, object>
                {
                    { "AppId", appId },
                    { "AppToken", appToken }
                };
        }
    }
}
