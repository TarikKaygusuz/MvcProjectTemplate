using MvcProject.Core.Domain.Entity;
using System.Linq;

namespace MvcProject.Service.Users
{
    public interface IUserService
    {
        /// <summary>
        /// Tüm kullanıcılar.
        /// </summary>
        /// <returns></returns>
        IQueryable<User> GetAll();

        /// <summary>
        /// Role göre kullanıcılar.
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        IQueryable<User> GetUsersByRole(string roleName);

        /// <summary>
        /// Kullanıcı sistemde kayıtlı mı.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool ValidateUser(string userName, string password);

        /// <summary>
        /// Kullanıcı bul.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        User Find(int userId);

        /// <summary>
        /// Kullanıcı ekle.
        /// </summary>
        /// <param name="user"></param>
        void Insert(User user);

        /// <summary>
        /// Kullanıcı güncelle.
        /// </summary>
        /// <param name="user"></param>
        void Update(User user);

        /// <summary>
        /// Kullanıcı sil.
        /// </summary>
        /// <param name="user">Kullanıcı</param>
        void Delete(User user);

        /// <summary>
        /// Kullanıcı sil.
        /// </summary>
        /// <param name="userId">Kullanıcı Id</param>
        void Delete(int userId);
    }
}