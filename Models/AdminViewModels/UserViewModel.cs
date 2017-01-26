using System;

namespace WebApplication.Models.AdminViewModels
{
    public class AdminUserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string roleName { get; set; }
        public string userId { get; set; }
        public int roleRank { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime LastLoginDate { get; set; }
    }

    
    


    //public IEnumerable<SelectListItem> GetUserRoles(string usrrole)
    //{
    //    List<AdminRoleViewModel> _roleList = new List<AdminRoleViewModel>();
    //    _roleList.Add(new AdminRoleViewModel() { Role = "Admin", RoleId = "1" });
    //    _roleList.Add(new AdminRoleViewModel() { Role = "Manager", RoleId = "2" });
    //    _roleList.Add(new AdminRoleViewModel() { Role = "Editor", RoleId = "3" });
    //    _roleList.Add(new AdminRoleViewModel() { Role = "Author", RoleId = "4" });
    //    _roleList.Add(new AdminRoleViewModel() { Role = "Member", RoleId = "5" });
    //    _roleList = _roleList.OrderBy(x => x.RoleId).ToList();

    //    List<SelectListItem> roleNames = new List<SelectListItem>();
    //    foreach (var role in _roleList)
    //    {
    //        roleNames.Add(new SelectListItem()
    //        {
    //            Text = role.Role,
    //            Value = role.Role
    //        });
    //    }
    //    var selectedRoleName = roleNames.FirstOrDefault(d => d.Value == usrrole);
    //    if (selectedRoleName != null)
    //    {
    //        selectedRoleName.Selected = true;
    //    }
    //    return roleNames;
    //}
}
