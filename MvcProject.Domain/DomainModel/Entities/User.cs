using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProject.Domain.DomainModel.Entities
{
    [Table("User")]
    public class User : Entity
    {
        public User()
        {
            this.Roles = new HashSet<Role>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(150)]
        public string DisplayName { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(150)]
        public string Email { get; set; }

        [StringLength(250)]
        public string ProfileImageUrl { get; set; }

        public DateTime LastLoginDate { get; set; }

        [StringLength(20)]
        public string LastLoginIP { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
