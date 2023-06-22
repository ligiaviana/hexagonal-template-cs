using HexagonalTemplate.Models.Entities;

namespace HexagonalTemplate.Ports.Ins
{
    public interface IFindAppUseCase
    {
        public AppEntity GetAppById(int id);
    }
}
