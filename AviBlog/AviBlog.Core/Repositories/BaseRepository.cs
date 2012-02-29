using System.Linq;

namespace AviBlog.Core.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public string Add(T entity)
        {
            throw new System.NotImplementedException();
        }

        public string Edit(T entity)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public T Find(T entity)
        {
            throw new System.NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}