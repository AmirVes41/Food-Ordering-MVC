using firstProj.DataAccess.Repository.IRepository;
using firstProj.DataAccess;
using firstProj.Models;
using firstProj.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Data;
using firstProject.Areas.Admin.Controllers;
using firstProj.Utility;
using Microsoft.AspNetCore.Authorization;
using firstProject.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace firstProject.Areas.Admin.Controllers
{


    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
           

            return View();
        }

       
        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<ApplicationUser> objUserList = _db.ApplicationUsers.Include(u=>u.Company).ToList();
            var userRoles = _db.UserRoles.ToList();
            var roles = _db.Roles.ToList();
            foreach (var user in objUserList)
            {
                var roleId = userRoles.FirstOrDefault(u => u.UserId == user.Id).RoleId;
                user.Role = roles.FirstOrDefault(u => u.Id == roleId).Name;
                if (user.Company == null)
                {
                    user.Company = new Company()
                    {
                        Name = "-"
                    };
                }

            }
            return Json(new { data = objUserList });
        }


        [HttpPost]
        public IActionResult LockUn([FromBody]string id)
        {
            var objFromDb = _db.ApplicationUsers.FirstOrDefault(u => u.Id == id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "خطا حین عملیات" });
            }

            if (objFromDb.LockoutEnd != null && objFromDb.LockoutEnd > DateTime.Now)
            {
                //user is currently locked and we need to unlock them
                objFromDb.LockoutEnd = DateTime.Now;
            }
            else
            {
                objFromDb.LockoutEnd = DateTime.Now.AddYears(1000);
            }
            _db.SaveChanges();
            return Json(new { success = true, message = "عملیات موفقیت آمیز بود." });
        }

        #endregion
    }
}
