using TCCB_QuanLy.Models.DAO;
using TCCB_QuanLy.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TCCB_QuanLy.Controllers
{
    [RoutePrefix("quanlytaikhoan")]
    public class QuanLyTaiKhoanController : Controller
    {
        IPermissionRepository permissionRepository;
        IGroupPermissionRepository groupPermissionRepository;
        IAccountRepository accountRepository;

        public QuanLyTaiKhoanController(IPermissionRepository permissionRepository, IGroupPermissionRepository groupPermissionRepository, IAccountRepository accountRepository)
        {
            this.permissionRepository = permissionRepository;
            this.groupPermissionRepository = groupPermissionRepository;
            this.accountRepository = accountRepository;
        }

        // GET: QuanLyTaiKhoan
        [Route("")]
        public ActionResult TaiKhoan()
        {
            List<Permission> permissions = permissionRepository.GetPermissions();
            List<GroupPermission> groupPermissions = groupPermissionRepository.GetGroupPermissions();
            IQueryable<Account> accounts = accountRepository.GetAccounts();
            ViewBag.Permissions = permissions;
            ViewBag.GroupPermissions = groupPermissions;
            ViewBag.Accounts = accounts;
            return View();
        }
    }
}