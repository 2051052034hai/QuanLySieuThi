using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLySieuThi.DTO;
using QuanLySieuThi.DAO;
using QuanLySieuThi.BUS;
using QuanLySieuThi.Controllers;
namespace QuanLySieuThi.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            CustomerBUS customerBUS = new CustomerBUS();
            Customer cus = customerBUS.GetCustomerById(1);
            ViewBag.Customer = cus;
            ViewBag.SuccessMsg = TempData["SuccessMsg"] as string;
            return View();
        }
        [HttpGet]
        public ActionResult ChangePassword()
        {
            CustomerBUS customerBUS = new CustomerBUS();
            Customer cus = customerBUS.GetCustomerById(1);
            ViewBag.Customer = cus;
            ViewBag.SuccessMsg = TempData["SuccessMsg"] as string;
            ViewBag.FailMsg = TempData["FailMsg"] as string;
            return View();
        }

        [HttpPost]
        public ActionResult Edit()
        {
            string ID = Request.Form["ID"];
            string fullname = Request.Form["fullname"];
            string phone = Request.Form["phone"];
            string address = Request.Form["address"];
            string password = Request.Form["password"];
            string point = Request.Form["point"];
            CustomerBUS customerBUS = new CustomerBUS();
            if (customerBUS.Update(ID, fullname, phone, address, password, Int32.Parse(point)) > 0)
                TempData["SuccessMsg"] = "Cập nhật thành công!!!";
            return RedirectToAction("Index", "Account");
        }
        [HttpPost]
        public ActionResult Change()
        {
            string ID = Request.Form["ID"];
            string password = Request.Form["password"];
            string confirm = Request.Form["confirm"];
            string newPass = Request.Form["newPassword"];
            CustomerBUS customerBUS = new CustomerBUS();
            if (customerBUS.Update(ID: ID, password: password, newPass: newPass) > 0)
                TempData["SuccessMsg"] = "Cập nhật thành công!!!";
            else
                TempData["FailMsg"] = "Cập nhật thất bại!!!";
            return Json(new { success = true });

        }
    }
}