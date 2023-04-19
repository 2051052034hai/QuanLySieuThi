using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLySieuThi.DTO;
using QuanLySieuThi.BUS;
using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.Owin;
//using Microsoft.Owin.Security;
using System.Web.Helpers;

namespace QuanLySieuThi.Controllers
{
    public class LoginController : Controller
    {
        //private ApplicationUserManager

        public void getAllCategories()
        {
            CategoryBUS categoryBUS = new CategoryBUS();
            List<Category> category = categoryBUS.GetCategories();
            ViewBag.Categories = category;
        }
        // GET: Login
        public ActionResult Index()
        {
            // Lấy loại sẩn phẩm từ cơ sở dữ liệu
            getAllCategories();
            ViewBag.FailMsg = TempData["FailMsg"] as string;
            return View();
        }
        public ActionResult Login()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Login(string loginType, string username, string password)
        {
            if (loginType.Equals("customer"))
            {
                CustomerBUS customerBUS = new CustomerBUS();
                if (customerBUS.Authenticate(username, password) != null)
                {
                    
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["FailMsg"] = "Đăng nhập thất bại!!! Username hoặc password không khớp";
                    return RedirectToAction("Index", "Login");
                }
            }
            else
            {
                EmployeeBUS employeeBUS = new EmployeeBUS();
            }
            // Authenticate the user here using the provided username and password
            if (true)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // If authentication fails, display an error message
                ViewBag.Error = "Invalid username or password. Please try again.";
                getAllCategories();
                return View();
            }
        }

        [HttpGet]
        public ViewResult Register()
        {
            // Lấy loại sẩn phẩm từ cơ sở dữ liệu
            getAllCategories();
            ViewBag.FailMsg = TempData["FailMsg"] as string;
            return View();
        }
        
        
        [HttpPost]
        public ActionResult AddCustomer()
        {
            // Dữ liệu nhận được từ client fetch lên
            string username = Request.Form["username"];
            string fullname = Request.Form["fullname"];
            string phone = Request.Form["phone"];
            string adress = Request.Form["address"];
            string password = Request.Form["password"];

            Customer cus = new Customer(fullname, adress, phone, password, username);
            CustomerBUS customerBUS = new CustomerBUS();
            if (customerBUS.Create(cus) > 0)
                return RedirectToAction("Login", "Login");
            else
            {
                TempData["FailMsg"] = "Đăng ký không thành công!!! Tài khoản đã có trong hệ thống";
                return RedirectToAction("Register", "Login");
            }     
        }

    }
}