using MvcProject.Core.Domain.Entity;
using System.Data.Entity.ModelConfiguration;


namespace MvcProject.Data.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User");
            HasKey(x => x.Id);
            Property(x => x.DisplayName).HasMaxLength(100);
            Property(x => x.Email).HasMaxLength(250);
            Property(x => x.LastLoginIp).HasMaxLength(20);
            Property(x => x.Password).HasMaxLength(50);
            Property(x => x.ProfileImageUrl).HasMaxLength(500);
            Property(x => x.UserName).HasMaxLength(50);

            HasMany(h => h.Roles).
            WithMany(e => e.Users).
            Map(
                m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("RoleId");
                    m.ToTable("User_Role");
                }
            );
        }
    }
}