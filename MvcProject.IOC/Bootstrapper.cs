using System.Web.Mvc;
using Microsoft.Practices.Unity;
using MvcProject.Core.Domain.Entity;
using MvcProject.Data.Repository;
using MvcProject.Data.UnitOfWork;
using MvcProject.Service.Roles;
using MvcProject.Service.Users;
using Unity.Mvc4;

namespace MvcProject.IOC
{
    /// <summary>
    /// Bind the given interface in request scope
    /// </summary>
    public static class IocExtensions
    {
        public static void BindInRequestScope<T1, T2>(this IUnityContainer container) where T2 : T1
        {
            container.RegisterType<T1, T2>(new HierarchicalLifetimeManager());
        }

        public static void BindInSingletonScope<T1, T2>(this IUnityContainer container) where T2 : T1
        {
            container.RegisterType<T1, T2>(new ContainerControlledLifetimeManager());
        }
    }

    public static class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            RegisterTypes(container);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            container.BindInRequestScope<IGenericRepository<User>, GenericRepository<User>>();
            container.BindInRequestScope<IGenericRepository<Role>, GenericRepository<Role>>();

            container.BindInRequestScope<IUnitOfWork, UnitOfWork>();

            container.BindInRequestScope<IUserService, UserService>();
            container.BindInRequestScope<IRoleService, RoleService>();
        }
    }
}