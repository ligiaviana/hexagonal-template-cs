using HexagonalTemplate.Models.Entities;
using HexagonalTemplate.Ports.Outs;

namespace HexagonalTemplate.Adapters.SqliteAdapters
{
    public class AppRepository : IAppRepository
    {
        private readonly AppRepositoryDbContext _context;

        public AppRepository(AppRepositoryDbContext context)
        {
            _context = context;
        }

        public AppEntity Create(AppEntity appEntity)
        {
            _context.Apps.Add(appEntity);
            _context.SaveChanges();

            return appEntity;
        }

        public AppEntity FindById(int id)
        {
            var app = _context.Apps.FirstOrDefault(u => u.AppId == id);
            return app;
        }
    }
}
