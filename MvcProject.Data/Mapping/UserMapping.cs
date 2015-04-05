using MvcProject.Domain.DomainModel.Entities;
using System.Data.Entity.ModelConfiguration;


namespace MvcProject.Data.Mapping
{
    public class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            // kullanici-rol ara tablosu oluşturma
            HasMany(h => h.Roles).
            WithMany(e => e.Users).
            Map(
                m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("RoleId");
                    m.ToTable("UserInRole");
                }
            );
        }
    }
}