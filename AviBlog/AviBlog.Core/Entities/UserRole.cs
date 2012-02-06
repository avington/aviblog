using System.Collections.Generic;

namespace AviBlog.Core.Entities
{
    public class UserRole
    {
        public int Id { get; set; }
        public ICollection<UserProfile> UserProfiles { get; set; }
        public string RoleName { get; set; }
    }
}