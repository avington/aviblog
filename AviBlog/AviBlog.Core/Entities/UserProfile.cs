using System.Collections.Generic;

namespace AviBlog.Core.Entities
{
    public class UserProfile
    {
        public int Id { get; set; }
        public virtual Blog Blog { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public virtual ICollection<UserRole> Roles { get; set; }
        public bool IsActive { get; set; }
        public string AboutMe { get; set; }
    }
}