using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLySieuThi.DTO;
using QuanLySieuThi.DAO;
using QuanLySieuThi.BUS;


namespace QuanLySieuThi.Controllers
{
    public class LoginController : Controller
    {
        public void getAllCategories()
        {
            CategoryBUS categoryBUS = new CategoryBUS();
            List<Category> category = categoryBUS.GetCategories();
            ViewBag.Categories = category;
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            // Lấy loại sẩn phẩm từ cơ sở dữ liệu
            getAllCategories();
           
            return View();
        }

        
        public ActionResult Register()
        {
            // Lấy loại sẩn phẩm từ cơ sở dữ liệu
            getAllCategories();


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

            Customer cus = new Customer(fullname, adress, phone, password);
            CustomerDAO dao = new CustomerDAO();
            dao.Create(cus);

            return RedirectToAction("Login", "Login");
        }
    }
}