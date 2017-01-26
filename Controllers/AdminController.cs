using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Data;
using WebApplication.Models;
using WebApplication.Models.AdminViewModels;
using WebApplication.Services;

namespace WebApplication.Controllers
{
    // [Authorize(Roles = "Admin,Manager")]
    [Authorize(Roles = "Admin,Manager")]
    public class AdminController : Controller
    {
        private ApplicationDbContext _dataContext;
        private IHostingEnvironment _environment;
        // private readonly UsersService _UsersService;
        private readonly UserManager<ApplicationUser> _userManager;

        public static string AdmUserName { get; set; }
        public static string AdmUserEmail { get; set; }
        public static string AdmUserRole { get; set; }
        
        private readonly SubscriberService _SubscriberService;
        public AdminController(ApplicationDbContext dataContext, UserManager<ApplicationUser> userManager, IHostingEnvironment environment)
        {
            _dataContext = dataContext;
            _environment = environment;
             _userManager = userManager;
             _SubscriberService = new SubscriberService(dataContext);

        }

        public IActionResult Index(DashBoardViewModel vm, AdminMessageId? message = null)
        {
            ViewData["StatusMessage"] =
             message == AdminMessageId.PhotoUploadSuccess ? "Your photo has been uploaded."
             : message == AdminMessageId.FileExtensionError ? "Error! Only jpg, jpeg, gif, and png file formats are allowed."
             : message == AdminMessageId.UserUpdated ? "User Updated Successfully"
             : message == AdminMessageId.postdeletesuccess ? "your post has been deleted."
             : message == AdminMessageId.Magazinedeletesuccess ? "your Magazine has been deleted."
             : message == AdminMessageId.Error ? "An error has occurred."
             : "";

            // var _user = await _UsersService.GetUserData(User.Identity.Name);

            
            vm.Subscribers = _SubscriberService.GetAllSubscribers();;

            return View(vm);
        }
        
        [Authorize(Roles = "Admin")]
        public IActionResult Users()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult EditUser(EditUserViewModel model)
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(string Id, EditUserViewModel model)
        {
            try
            {
                //TODO: ADdd update Logic here
                var user = await _userManager.FindByIdAsync(Id);
                model.Email = user.Email;
                var roles = await _userManager.GetRolesAsync(user);
                model.UserName = user.UserName;
                foreach (var role in roles)
                {
                    model.RoleName = role;
                }
                AdmUserName = model.UserName;
                AdmUserEmail = model.Email;
                AdmUserRole = model.RoleName;
                return RedirectToAction("EditUser");

                // var user = await _userManager.FindByIdAsync(Id);
                // model.Email = user.Email;
                // var usersroles = await _userManager.GetRolesAsync(user);
                // model.UserName = user.UserName;
                // foreach (var role in usersroles)
                // {
                //     model.RoleName += role;
                // }
                // AdmUserEmail = model.Email;
                // AdmUserRole = model.RoleName;
                // AdmUserName = model.UserName;
                // // var userId = _dataContext.Users.Where(x => x.UserName == AdmUserName).Select(x => x.Id).FirstOrDefault();
                // var userRoles = await _userManager.GetRolesAsync(user);
                // string[] roles = new string[userRoles.Count];
                // userRoles.CopyTo(roles, 0);
                // await _userManager.RemoveFromRolesAsync(user, roles);
                // await _userManager.AddToRoleAsync(user, AdmUserRole);
                // return RedirectToAction(nameof(Index), new { Message = AdminMessageId.UserUpdated });

            }
            catch
            {
                return View(model);
            }
        }

        
         public enum AdminMessageId
        {
            PhotoUploadSuccess,
            FileUploadSuccess,
            VideoUploadSuccess,
            FileExtensionError,
            FileExistError,
            postdeletesuccess,
            Magazinedeletesuccess,
            UserUpdated,
            FileSizeError,
            Error,
        }
    }
}