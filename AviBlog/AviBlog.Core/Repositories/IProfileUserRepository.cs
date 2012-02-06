using System.Linq;
using AviBlog.Core.Entities;

namespace AviBlog.Core.Repositories
{
    public interface IProfileUserRepository
    {
        IQueryable<UserProfile> GetUserProfiles();
    }
}