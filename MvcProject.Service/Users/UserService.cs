using MvcProject.Core.Domain.Entity;
using MvcProject.Data.Repository;
using MvcProject.Data.UnitOfWork;
using System.Linq;

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
    }
}