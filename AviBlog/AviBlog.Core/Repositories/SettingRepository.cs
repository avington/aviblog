using System.Configuration;
using System.Linq;
using AviBlog.Core.Context;
using AviBlog.Core.Entities;

namespace AviBlog.Core.Repositories
{
    public class SettingRepository : ISettingRepository
    {
        private readonly BlogContext _context;

        public SettingRepository()
        {
            string connection = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            _context = new BlogContext(connection);
        }
        public string Add(Setting entity)
        {
            if (entity == null) return "The entity was not provided.";
            _context.Settings.Add(entity);
            _context.SaveChanges();
            _context.Dispose();
            return string.Empty;
        }

        public string Edit(Setting entity)
        {
            if (entity == null) return "the entity was not provided.";
            var current = _context.Settings.Find(entity.Id);
            if (current == null) return "the specified setting was not found.";
            current.Entry = entity.Entry;
            current.Key = entity.Key;
            _context.SaveChanges();
            _context.Dispose();
            return string.Empty;
        }

        public IQueryable<Setting> GetAll()
        {
            return _context.Settings.AsQueryable();
        }

        public Setting FindById(int id)
        {
            return _context.Settings.Find(id);
        }

        public string Delete(int id)
        {
            var current = _context.Settings.Find(id);
            if (current == null) return "The specified setting was not found.";
            _context.Settings.Remove(current);
            return string.Empty;
        }
    }
}