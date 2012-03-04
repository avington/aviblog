using System.Configuration;
using System.Linq;
using AviBlog.Core.Context;
using AviBlog.Core.Entities;

namespace AviBlog.Core.Repositories
{
    public class PingRepository : IPingRepository
    {
        private readonly BlogContext _context;

        public PingRepository()
        {
            string connection = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            _context = new BlogContext(connection);
        }

        public IQueryable<PingService> GetAll()
        {
            return _context.PingServices.AsQueryable();
        }

        public PingService GetById(int id)
        {
            return _context.PingServices.Find(id);
        }

        public string Add(PingService entity)
        {
            if (entity == null) return "No Ping Service was provided.";
            PingService temp = new PingService {PingUrl = entity.PingUrl};
            _context.PingServices.Add(temp);
            _context.SaveChanges();
            _context.Dispose();
            return string.Empty;
        }

        public string Update(PingService entity)
        {
            if (entity == null) return "No Ping Service was provided.";
            PingService temp = _context.PingServices.Find(entity.Id);
            if (temp == null) return "the specified ping service was not found.";
            temp.PingUrl = entity.PingUrl;
            _context.SaveChanges();
            _context.Dispose();
            return string.Empty;

        }

        public string Delete(int id)
        {
            PingService temp = _context.PingServices.Find(id);
            if (temp == null) return "the specified ping service was not found.";
            _context.PingServices.Remove(temp);
            _context.SaveChanges();
            _context.Dispose();
            return string.Empty;
        }
    }
}