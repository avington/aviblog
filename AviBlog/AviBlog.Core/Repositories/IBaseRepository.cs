using System.Linq;

namespace AviBlog.Core.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        string Add(T entity);
        string Edit(T entity);
        IQueryable<T> GetAll();
        T Find(T entity);
        string Delete(int id);
    }
}