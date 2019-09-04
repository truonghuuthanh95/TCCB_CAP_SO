using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCCB_QuanLy.Models.DAO;
using TCCB_QuanLy.Models.DTO;
using TCCB_QuanLy.Repositories.Interfaces;
using TCCB_QuanLy.Utils;

namespace TCCB_QuanLy.Controllers
{
    public class LoginController : Controller
    {
        IAccountRepository accountRepository;
        IUserPermissionRepository userPermissionRepository;
        IAccountSchoolRepository accountSchoolRepository;

        public LoginController(IAccountRepository accountRepository, IUserPermissionRepository userPermissionRepository, IAccountSchoolRepository accountSchoolRepository)
        {
            this.accountRepository = accountRepository;
            this.userPermissionRepository = userPermissionRepository;
            this.accountSchoolRepository = accountSchoolRepository;
        }


        // GET: Login
        [Route("login", Name = "login")]
        public ActionResult Login()
        {
            return View();
        }
        [Route("requestLogin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RequestLogin(string username, string password)
        {
            Account account = accountRepository.GetAccountByUsernameAndPassword(username, password);
            if (account == null)
            {
                return Json(new ReturnResult(400, "Sai tên truy cập hoặc mật khẩu", null), JsonRequestBehavior.AllowGet);
            }
            else if (account.IsActive == false)
            {
                return Json(new ReturnResult(400, "Tài khoản hiện đang bị khóa", null), JsonRequestBehavior.AllowGet);
            }
            List<UserPermission> userPermissions = userPermissionRepository.GetUserPermissionsByAccountId(account.Id);
            Session[Constants.USER_SESSION] = account;
            Session[Constants.USER_PERMISSION_SESSION] = userPermissions;
            return Json(new ReturnResult(200, "success", null), JsonRequestBehavior.AllowGet);
        }
        [Route("logout")]
        public ActionResult Logout()
        {
            Session.RemoveAll();
            return RedirectToRoute("login");
        }

        [Route("schoollogin", Name = "schoolLogin")]
        public ActionResult SchoolLogin()
        {
            List<AccountSchool> accountSchools = accountSchoolRepository.GetAccountSchools();
            ViewBag.AccountSchools = accountSchools;
            return View();
        }
        [Route("requestSchoolLogin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RequestSchoolLogin(int schoolId, string password)
        {
            AccountSchool account = accountSchoolRepository.GetAccountSchoolById(schoolId);
            if (account == null)
            {
                return Json(new ReturnResult(400, "Sai tên truy cập hoặc mật khẩu", null), JsonRequestBehavior.AllowGet);
            }
            else if (account.Password.Trim() != password.Trim())
            {
                return Json(new ReturnResult(400, "Mật khẩu không đúng", null), JsonRequestBehavior.AllowGet);
            }
            
            Session[Constants.USER_SCHOOL_SESSION] = account;
            
            return Json(new ReturnResult(200, "success", null), JsonRequestBehavior.AllowGet);
        }
    }
}