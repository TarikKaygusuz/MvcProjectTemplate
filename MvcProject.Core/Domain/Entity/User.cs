using System;
using System.Collections.Generic;

namespace MvcProject.Core.Domain.Entity
{
    public class User : BaseEntity
    {
        public User()
        {
            Roles = new HashSet<Role>();
        }

        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string ProfileImageUrl { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string LastLoginIp { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}