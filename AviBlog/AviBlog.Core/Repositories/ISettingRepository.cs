using System.Linq;
using AviBlog.Core.Entities;

namespace AviBlog.Core.Repositories
{
    public interface ISettingRepository
    {
        string Add(Setting entity);
        string Edit(Setting entity);
        IQueryable<Setting> GetAll();
        Setting FindById(int id);
        string Delete(int id);
    }
}