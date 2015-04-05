using System;
using MvcProject.Core.Domain.Entity;
using MvcProject.Data.Repository;
using MvcProject.Data.UnitOfWork;
using System.Linq;
using System.Net.Mail;

namespace MvcProject.Service.Users
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IGenericRepository<Role> _roleRepository;
        private readonly IGenericRepository<User> _userRepository;

        public UserService(IUnitOfWork uow)
        {
            _uow = uow;
            _roleRepository = uow.GetRepository<Role>();
            _userRepository = uow.GetRepository<User>();
        }

        /// <summary>
        /// Tüm kullanıcılar.
        /// </summary>
        /// <returns></returns>
        public IQueryable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        /// <summary>
        /// Role göre kullanıcılar.
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public IQueryable<User> GetUsersByRole(string roleName)
        {
            return _roleRepository.GetAll().FirstOrDefault(x => x.RoleName == roleName).Users.AsQueryable();
        }

        /// <summary>
        /// Kullanıcı sistemde kayıtlı mı.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool ValidateUser(string userName, string password)
        {
            return _userRepository.GetAll().Any(x => x.UserName == userName && x.Password == password);
        }

        /// <summary>
        /// Kullanıcı bul.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public User Find(int userId)
        {
            return _userRepository.Find(userId);
        }

        /// <summary>
        /// Kullanıcı ekle.
        /// </summary>
        /// <param name="user"></param>
        public void Insert(User user)
        {
            _userRepository.Insert(user);
        }

        /// <summary>
        /// Kullanıcı güncelle.
        /// </summary>
        /// <param name="user"></param>
        public void Update(User user)
        {
            _userRepository.Update(user);
        }

        /// <summary>
        /// Kullanıcı sil.
        /// </summary>
        /// <param name="user">Kullanıcı</param>
        public void Delete(User user)
        {
            _userRepository.Delete(user);
        }

        /// <summary>
        /// Kullanıcı sil.
        /// </summary>
        /// <param name="userId">Kullanıcı Id</param>
        public void Delete(int userId)
        {
            _userRepository.Delete(userId);
        }

        /// <summary>
        /// Confirmation mail'i gönder.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="email"></param>
        /// <param name="confirmationUrl"></param>
        public void SendConfirmationMail(int userId, string email, string confirmationUrl)
        {
            var user = Find(userId);
            string confirmationId = user.ConfirmationId.ToString();
            confirmationUrl += "/Account/ConfirmUser?confirmationId=" + confirmationId;

            var message = new MailMessage("tarikkaygusuz@gmail.com", email)
            {
                Subject = "Lütfen e-posta adresinizi onaylayınız.",
                Body = confirmationUrl
            };

            var client = new SmtpClient();

            client.Send(message);
        }

        /// <summary>
        /// Mail sistemde kullanılıyor mu?
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool ValidateEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// UserName sistemde kullanılıyor mu?
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool ValidateUserName(string userName)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// ConfirmationId gönderilmiş User döner. isConfirmed kontrolü yapılabilir.
        /// </summary>
        /// <param name="confirmationId"></param>
        /// <returns></returns>
        public User Find(Guid confirmationId)
        {
            throw new NotImplementedException();
        }

        public bool FindByUserNameAndPassword(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}