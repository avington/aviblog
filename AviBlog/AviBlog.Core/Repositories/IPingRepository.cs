using System.Linq;
using AviBlog.Core.Entities;

namespace AviBlog.Core.Repositories
{
    public interface IPingRepository
    {
        IQueryable<PingService> GetAll();
        PingService GetById(int id);
        string Add(PingService entity);
        string Update(PingService entity);
        string Delete(int id);
    }
}