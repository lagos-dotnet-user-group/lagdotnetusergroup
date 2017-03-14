using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Data;
using WebApplication.Models;
using WebApplication.Models.AdminViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication.Services
{
    public class UsersService
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        public static List<AdminUserViewModel> userList = new List<AdminUserViewModel>();

        public UsersService(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
            //_rolemanager = rolemanager;
        }
        public async Task<IEnumerable<String>> GetRolesForUser(ApplicationUser user)
        {
            //using (
            //    var userManager =
            //        new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
            //var userid = await _userManager.GetUserIdAsync()
            var rolesForUser = await _userManager.GetRolesAsync(user);
            var usersroles = rolesForUser.ToArray();

            return (usersroles);
        }

        public IEnumerable<ApplicationUser> GetUsers()
        {
            //var _users = _db.Users.ToArray();
            var _users = _db.Users.ToArray();
            if (_users == null)
            {
                return null;
            }

            //foreach (var _user in _users)
            //{
            //    _user.Roles.Where(x => x.)
            //}
            //foreach (var _user in _users)
            //{
            //    return _user.Where(x => x.)
            //    //var users = _db.Users
            //    //    .Where(x => x.Roles.Select(y => _users.Id).Contains(roleId))
            //    //    .ToList();
            //}
            return _users;

        }

        public async Task<IEnumerable<AdminUserViewModel>> generateUserList()
        {
            userList.Clear();
            var model = new AdminUserViewModel();
            var users = _db.Users.ToList();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                model.UserName = user.UserName;
                foreach (var role in roles)
                {
                    model.roleName = role;
                    switch (role)
                    {
                        case "Admin":
                            model.roleRank = 1;
                            break;
                        case "Manager":
                            model.roleRank = 2;
                            break;
                        case "Editor":
                            model.roleRank = 3;
                            break;
                        case "Member":
                            model.roleRank = 4;
                            break;
                    }
                }
                model.userId = user.Id;
                model.FirstName = user.FirstName;
                model.LastName = user.LastName;
                model.UserEmail = user.Email;
                model.JoinDate = user.JoinDate;
                model.LastLoginDate = user.LastLoginDate;
                userList.Add(model);
                model.roleName = null;
            }
            return userList;
        }

        public async Task<ApplicationUser> GetUserData(string username)
        {
            var _user = await _userManager.FindByNameAsync(username);
            if (_user == null)
            {
                return null;
            }

            return _user;

        }

        public IEnumerable<SelectListItem> GetUserRoles(string usrrole)
        {
           List<RoleViewModel> _roleList = new List<RoleViewModel>();
           _roleList.Add(new RoleViewModel() { Role = "Admin", RoleId = "1" });
           _roleList.Add(new RoleViewModel() { Role = "Manager", RoleId = "2" });
           _roleList.Add(new RoleViewModel() { Role = "Editor", RoleId = "3" });
           _roleList.Add(new RoleViewModel() { Role = "Author", RoleId = "4" });
           _roleList.Add(new RoleViewModel() { Role = "Member", RoleId = "5" });
           _roleList = _roleList.OrderBy(x => x.RoleId).ToList();

           List<SelectListItem> roleNames = new List<SelectListItem>();
           foreach (var role in _roleList)
           {
               roleNames.Add(new SelectListItem()
               {
                   Text = role.Role,
                   Value = role.Role
               });
           }
           var selectedRoleName = roleNames.FirstOrDefault(d => d.Value == usrrole);
           if (selectedRoleName != null)
           {
               selectedRoleName.Selected = true;
           }
           return roleNames;
        }


    }
}