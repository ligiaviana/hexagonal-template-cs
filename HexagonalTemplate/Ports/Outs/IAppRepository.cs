using HexagonalTemplate.Models.Entities;

namespace HexagonalTemplate.Ports.Outs
{
    public interface IAppRepository
    {
        public AppEntity Create(AppEntity appEntity);
        public AppEntity FindById(int id);

    }
}
