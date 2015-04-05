using System.Collections.Generic;

namespace MvcProject.Core.Domain.Entity
{
    public class Role : BaseEntity
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public string RoleName { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}