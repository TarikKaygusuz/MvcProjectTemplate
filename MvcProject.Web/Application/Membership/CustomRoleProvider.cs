using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcProject.Service.Roles;

namespace MvcProject.Web.Application.Membership
{
    public class CustomRoleProvider : RoleProvider
    {
        public static IRoleService _roleService
        {
            get
            {
                return DependencyResolver.Current.GetService<RoleService>();
            }
        }

        public override bool IsUserInRole(string userName, string roleName)
        {
            return _roleService.IsUserInRole(userName, roleName);
        }

        public override string[] GetRolesForUser(string username)
        {
            return _roleService.GetRolesByUserName(username).Select(x => x.RoleName).ToArray<string>();
        }

        #region not implemented
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new System.NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new System.NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new System.NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new System.NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new System.NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new System.NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new System.NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}