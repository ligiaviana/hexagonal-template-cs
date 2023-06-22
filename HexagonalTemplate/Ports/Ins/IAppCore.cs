using HexagonalTemplate.Models.Entities;

namespace HexagonalTemplate.Ports.Ins
{
    public interface IAppCore
    {
        public void ValidateApp(AppEntity appEntity);
    }
}
