using AviBlog.Core.Entities;

namespace AviBlog.Core.Services
{
    public interface IPingHttpPostService
    {
        void Ping(Post entity);
    }
}