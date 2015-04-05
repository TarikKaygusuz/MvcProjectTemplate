using MvcProject.Core.Domain.Entity;
using System.Collections.Generic;
using System.Linq;
 
namespace MvcProject.Service.Roles
{
    public interface IRoleService
    {
        /// <summary>
        /// Tüm roller.
        /// </summary>
        /// <returns></returns>
        IQueryable<Role> GetAll();
 
        /// <summary>
        /// Kullanıcıya göre roller.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        IQueryable<Role> GetRolesByUser(string userName);
 
        /// <summary>
        /// Rol bul.
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Role Find(int roleId);
 
        /// <summary>
        /// Kullanıcı role sahip mi.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        bool IsUserInRole(string userName, string roleName);
 
        /// <summary>
        /// Kullanıcı ekle.
        /// </summary>
        /// <param name="role"></param>
        void Insert(Role role);
 
        /// <summary>
        /// Kullanıcı güncelle.
        /// </summary>
        /// <param name="role"></param>
        void Update(Role role);
 
        /// <summary>
        /// Kullanıcı sil.
        /// </summary>
        /// <param name="role">Rol</param>
        void Delete(Role role);
 
        /// <summary>
        /// Kullanıcı sil.
        /// </summary>
        /// <param name="roleId">Rol Id</param>
        void Delete(int roleId);

        /// <summary>
        /// Kullanıcı adına göre Role'leri getir.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        IQueryable<Role> GetRolesByUserName(string username);
    }
}
