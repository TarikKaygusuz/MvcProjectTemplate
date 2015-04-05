using System;
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

        /// <summary>
        /// Confirmation mail'i gönder.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="email"></param>
        /// <param name="confirmationUrl"></param>
        void SendConfirmationMail(int id, string email, string confirmationUrl);

        /// <summary>
        /// Mail sistemde kullanılıyor mu?
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        bool ValidateEmail(string email);

        /// <summary>
        /// UserName sistemde kullanılıyor mu?
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        bool ValidateUserName(string userName);

        /// <summary>
        /// ConfirmationId gönderilmiş User döner. isConfirmed kontrolü yapılabilir.
        /// </summary>
        /// <param name="confirmationId"></param>
        /// <returns></returns>
        User Find(Guid confirmationId);

        /// <summary>
        /// Kayıtlı kullanıcı ise true döner.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool FindByUserNameAndPassword(string userName, string password);
    }
}