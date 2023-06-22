using HexagonalTemplate.Models.Entities;
using HexagonalTemplate.Ports.Ins;

namespace HexagonalTemplate.Cores
{
    public class AppCore : IAppCore
    {
        public void ValidateApp(AppEntity appEntity)
        {
            if (appEntity == null)
                throw new ArgumentNullException(nameof(appEntity));

            if (string.IsNullOrEmpty(appEntity.AppName))
                throw new ArgumentNullException("AppName should be informed.");
        }
    }
}
