using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProject.Domain.DomainModel.Entities
{
    [Table("Role")]
    public class Role : Entity
    {
        public Role()
        {
            this.Users = new HashSet<User>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}